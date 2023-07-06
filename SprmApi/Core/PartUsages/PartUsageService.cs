using System.Transactions;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Core.Parts;
using SprmApi.Core.PartUsages.DTOs;
using SprmApi.MiddleWares;

namespace SprmApi.Core.PartUsages
{
    /// <summary>
    /// Part usage service
    /// </summary>
    public class PartUsageService : IPartUsageService
    {
        private readonly IPartUsageDAO _partUsageDAO;

        private readonly IPartDAO _partDAO;

        private readonly IPartVersionDAO _partVersionDAO;

        private readonly HeaderData _headerData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="partUsageDAO"></param>
        /// <param name="partDAO"></param>
        /// <param name="partVersionDAO"></param>
        /// <param name="headerData"></param>
        public PartUsageService(
            IPartUsageDAO partUsageDAO,
            IPartDAO partDAO,
            IPartVersionDAO partVersionDAO,
            HeaderData headerData)
        {
            _partUsageDAO = partUsageDAO;
            _partDAO = partDAO;
            _partVersionDAO = partVersionDAO;
            _headerData = headerData;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PartUsage>> GetByPartVersionIdAsync(long parentPartVersionId)
        {
            return await _partUsageDAO.GetByPartVersionIdAsync(parentPartVersionId, true);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PartUsage>> InsertAsync(CreatePartUsagesDTO usagesDTO)
        {
            TransactionOptions transactionOptions = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
            {
                List<PartUsage> partUsages = new List<PartUsage>();

                await ValidateUsagesAsync(usagesDTO.PartVersionId, usagesDTO.Children.Select(child => child.PartId));

                foreach (var child in usagesDTO.Children)
                {
                    var newUsage = await _partUsageDAO.InsertAsync(usagesDTO.PartVersionId, child, _headerData.JWTPayload.Subject);
                    newUsage = await _partUsageDAO.GetAsync(newUsage.Id, true);
                    partUsages.Add(newUsage!);
                }

                scope.Complete();
                return partUsages;
            }
        }

        /// <summary>
        /// 驗證Part usages是否存在
        /// </summary>
        /// <param name="parentPartVersionId">Parent part version id</param>
        /// <param name="childPartIds">Child part ids</param>
        /// <returns></returns>
        /// <exception cref="SprmException"></exception>
        private async Task ValidateUsagesAsync(long parentPartVersionId, IEnumerable<long> childPartIds)
        {
            var parentVersion = await _partVersionDAO.GetAsync(parentPartVersionId, false);
            if (parentVersion == null)
            {
                throw new SprmException(ErrorCode.DbDataNotFound, $"Parent part version id: {parentPartVersionId} does not exist");
            }
            foreach (var childPartId in childPartIds)
            {
                var childPart = await _partDAO.GetByIdAsync(childPartId);
                if (childPart == null)
                {
                    throw new SprmException(ErrorCode.DbDataNotFound, $"Child part id: {childPartId} does not exist");
                }
            }
        }

        /// <inheritdoc/>
        public async Task<PartUsage?> GetById(long id)
        {
            return await _partUsageDAO.GetAsync(id, true);
        }

        /// <inheritdoc/>
        public async Task DeleteById(long id)
        {
            await _partUsageDAO.DeleteAsync(id);
        }

        /// <inheritdoc/>
        public async Task UpdateById(long id, UpdatePartUsageDTO updateData)
        {
            var targetusage = await _partUsageDAO.GetAsync(id, false);
            if (targetusage == null)
            {
                throw new SprmException(ErrorCode.DbDataNotFound, $"Part usage id: {id} does not exist!");
            }
            targetusage = updateData.ApplyUpdate(targetusage);
            await _partUsageDAO.UpdateAsync(targetusage, _headerData.JWTPayload.Subject);
        }
    }
}
