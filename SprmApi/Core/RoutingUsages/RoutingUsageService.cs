using Microsoft.EntityFrameworkCore;
using SprmCommon.Error;
using SprmCommon.Exceptions;
using SprmApi.Core.RoutingUsages.Dto;
using SprmApi.MiddleWares;

namespace SprmApi.Core.RoutingUsages
{
    /// <summary>
    /// Routing usage service
    /// </summary>
    public class RoutingUsageService : IRoutingUsageService
    {
        private readonly IRoutingUsageDao _routingUsageDAO;

        private readonly HeaderData _headerData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="routingUsageDAO"></param>
        /// <param name="headerData"></param>
        public RoutingUsageService(IRoutingUsageDao routingUsageDAO, HeaderData headerData)
        {
            _routingUsageDAO = routingUsageDAO;
            _headerData = headerData;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RoutingUsageDto>> GetByRootVersionIdAsync(long rootVersionId)
        {
            IQueryable<RoutingUsage> usages = _routingUsageDAO.GetByRootVersionId(rootVersionId);
            IQueryable<RoutingUsageDto> dtos = usages.Select(usage => RoutingUsageDto.Parse(usage));
            return await dtos.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<RoutingUsageDto> InsertAsync(CreateRoutingUsageDto createDto)
        {
            RoutingUsage newUsage = await _routingUsageDAO.InsertAsync(createDto, _headerData.JWTPayload.Subject);
            RoutingUsage? includedNewUsage = await _routingUsageDAO.GetAsync(newUsage.Id);
            if (includedNewUsage == null)
            {
                throw new SprmException(ErrorCode.DbError, "Something went wrong");
            }
            return RoutingUsageDto.Parse(includedNewUsage);
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(long id)
        {
            await _routingUsageDAO.DeleteAsync(id);
        }

        /// <inheritdoc/>
        public async Task UpdateById(long id, UpdateRoutingUsageDto updateData)
        {
            var targetusage = await _routingUsageDAO.GetAsync(id);
            if (targetusage == null)
            {
                throw new SprmException(ErrorCode.DbDataNotFound, $"Part usage id: {id} does not exist!");
            }
            targetusage = updateData.ApplyUpdate(targetusage);
            await _routingUsageDAO.UpdateAsync(targetusage, _headerData.JWTPayload.Subject);
        }
    }
}
