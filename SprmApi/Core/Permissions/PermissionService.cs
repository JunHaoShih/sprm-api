using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using SprmApi.Core.AppUsers;
using SprmApi.Core.Permissions.Dto;
using SprmApi.Core.RabbitMq;
using SprmApi.Settings;
using SprmCommon.Amqp;
using SprmCommon.Error;
using SprmCommon.Exceptions;
using System.Text;
using System.Text.Json;
using System.Transactions;

namespace SprmApi.Core.Permissions
{
    /// <summary>
    /// Permission service
    /// </summary>
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionDao _permissionDao;

        private readonly IAppUserDao _appUserDao;

        private readonly IRabbitMqService _rabbitMqService;

        private readonly AmqpSettings _amqpSettings;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="permissionDao"></param>
        /// <param name="appUserDao"></param>
        /// <param name="mqService"></param>
        /// <param name="apiSettings"></param>
        public PermissionService(
            IPermissionDao permissionDao,
            IAppUserDao appUserDao,
            IRabbitMqService mqService,
            ApiSettings apiSettings
        )
        {
            _permissionDao = permissionDao;
            _appUserDao = appUserDao;
            _rabbitMqService = mqService;
            _amqpSettings = apiSettings.AmqpSettings;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PermissionDto>> GetByUserIdAsync(long userId)
        {
            await ValidateUser(userId);
            IQueryable<Permission> permissionsQuery = _permissionDao.GetByUserId(userId);
            List<Permission> permissions = await permissionsQuery.ToListAsync();
            return permissions.Select(p => PermissionDto.Parse(p));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PermissionDto>> GetByUserNameAsync(string username)
        {
            AppUser? user = await _appUserDao.GetByUsernameAsync(username);
            if (user == null)
            {
                throw new SprmException(ErrorCode.UserNotExist, $"Username {username} does not exist");
            }
            IQueryable<Permission> permissionsQuery = _permissionDao.GetByUserId(user.Id);
            List<Permission> permissions = await permissionsQuery.ToListAsync();
            return permissions.Select(p => PermissionDto.Parse(p));
        }

        /// <inheritdoc/>
        public async Task SaveAsync(IEnumerable<SavePermissionDto> permissionDtos, long userId, string requestUser)
        {
            await ValidateUser(userId);
            TransactionOptions transactionOptions = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
            {
                List<Permission> permissions = await _permissionDao.GetByUserId(userId).ToListAsync();
                foreach (SavePermissionDto permissionDto in permissionDtos)
                {
                    Permission? targetPermission = permissions.SingleOrDefault(p => p.ObjectTypeId == (long)permissionDto.ObjectType);
                    if (targetPermission == null)
                    {
                        await _permissionDao.InsertAsync(permissionDto.ToEntity(userId), requestUser);
                    }
                    else
                    {
                        await _permissionDao.UpdateAsync(permissionDto.ApplyUpdate(targetPermission), requestUser);
                    }
                }

                scope.Complete();
            }

            SendNotify(userId, NotifyType.PermissionChanged, NotifyLevel.WarningNotify);
        }

        private void SendNotify(long userId, NotifyType notifyType, NotifyLevel level)
        {
            IModel channel = _rabbitMqService.CreateChannel();

            channel.QueueDeclare(
                queue: _amqpSettings.NotifyQueueName,
                durable: true,
                exclusive: false,
                autoDelete: false
            );

            MqPayload<long> payload = new()
            {
                NotifyLevel = level,
                NotifyType = notifyType,
                Content = userId
            };

            string json = JsonSerializer.Serialize(payload);

            byte[] body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(
                exchange: string.Empty,
                routingKey: _amqpSettings.NotifyQueueName,
                basicProperties: null,
                body: body
            );

            channel.Close();
        }

        private async Task ValidateUser(long userId)
        {
            AppUser? creator = await _appUserDao.GetAsync(userId);
            if (creator == null)
            {
                throw new SprmException(ErrorCode.UserNotExist, $"User id {userId} does not exist");
            }
        }
    }
}
