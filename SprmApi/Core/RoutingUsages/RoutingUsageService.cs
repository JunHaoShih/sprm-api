using Microsoft.EntityFrameworkCore;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Core.RoutingUsages.DTOs;
using SprmApi.MiddleWares;

namespace SprmApi.Core.RoutingUsages
{
    /// <summary>
    /// Routing usage service
    /// </summary>
    public class RoutingUsageService : IRoutingUsageService
    {
        private readonly IRoutingUsageDAO _routingUsageDAO;

        private readonly HeaderData _headerData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="routingUsageDAO"></param>
        /// <param name="headerData"></param>
        public RoutingUsageService(IRoutingUsageDAO routingUsageDAO, HeaderData headerData)
        {
            _routingUsageDAO = routingUsageDAO;
            _headerData = headerData;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RoutingUsageDTO>> GetByRootVersionIdAsync(long rootVersionId)
        {
            IQueryable<RoutingUsage> usages = _routingUsageDAO.GetByRootVersionId(rootVersionId);
            IQueryable<RoutingUsageDTO> dtos = usages.Select(usage => RoutingUsageDTO.Parse(usage));
            return await dtos.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<RoutingUsageDTO> InsertAsync(CreateRoutingUsageDTO createDto)
        {
            RoutingUsage newUsage = await _routingUsageDAO.InsertAsync(createDto, _headerData.JWTPayload.Subject);
            RoutingUsage? includedNewUsage = await _routingUsageDAO.GetAsync(newUsage.Id);
            if (includedNewUsage == null)
            {
                throw new SPRMException(ErrorCode.DbError, "Something went wrong");
            }
            return RoutingUsageDTO.Parse(includedNewUsage);
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(long id)
        {
            await _routingUsageDAO.DeleteAsync(id);
        }

        /// <inheritdoc/>
        public async Task UpdateById(long id, UpdateRoutingUsageDTO updateData)
        {
            var targetusage = await _routingUsageDAO.GetAsync(id);
            if (targetusage == null)
            {
                throw new SPRMException(ErrorCode.DbDataNotFound, $"Part usage id: {id} does not exist!");
            }
            targetusage = updateData.ApplyUpdate(targetusage);
            await _routingUsageDAO.UpdateAsync(targetusage, _headerData.JWTPayload.Subject);
        }
    }
}
