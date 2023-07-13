using Microsoft.EntityFrameworkCore;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Core.AppUsers;
using SprmApi.Core.Permissions.Dto;
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="permissionDao"></param>
        /// <param name="appUserDao"></param>
        public PermissionService(IPermissionDao permissionDao, IAppUserDao appUserDao)
        {
            _permissionDao = permissionDao;
            _appUserDao = appUserDao;
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
