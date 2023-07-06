using SprmApi.Common.Exceptions;
using SprmApi.Common.Paginations;
using SprmApi.Core.Routings.DTOs;
using SprmApi.MiddleWares;

namespace SprmApi.Core.Routings
{
    /// <summary>
    /// Routing version service
    /// </summary>
    public class RoutingVersionService : IRoutingVersionService
    {
        private readonly IRoutingDAO _routingDAO;

        private readonly IRoutingVersionDAO _routingVersionDAO;

        private readonly HeaderData _headerData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="routingDAO"></param>
        /// <param name="routingVersionDAO"></param>
        /// <param name="headerData"></param>
        public RoutingVersionService(
            IRoutingDAO routingDAO,
            IRoutingVersionDAO routingVersionDAO,
            HeaderData headerData
            )
        {
            _routingDAO = routingDAO;
            _routingVersionDAO = routingVersionDAO;
            _headerData = headerData;
        }

        /// <inheritdoc/>
        public async Task<RoutingVersionDto?> GetAsync(long id)
        {
            RoutingVersion? target = await _routingVersionDAO.GetAsync(id);
            if (target == null)
            {
                return null;
            }
            return RoutingVersionDto.Parse(target);
        }

        /// <inheritdoc/>
        public async Task<OffsetPagination<RoutingVersionDto>> GetByMasterId(long masterId, OffsetPaginationInput input)
        {
            Routing? targetRouting = await _routingDAO.GetByIdAsync(masterId);
            if (targetRouting == null)
            {
                throw new SprmException(Common.Error.ErrorCode.DbDataNotFound, $@"Routing id: {masterId} not found!");
            }
            IQueryable<RoutingVersion> versions = _routingVersionDAO.GetByMasterId(masterId);
            var dtos = versions.Select(version => RoutingVersionDto.Parse(version));
            OffsetPagination<RoutingVersionDto> offsetPagination = new OffsetPagination<RoutingVersionDto>(dtos, input);
            return offsetPagination;
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(long id, UpdateRoutingVersionDto update)
        {
            RoutingVersion? targetVersion = await _routingVersionDAO.GetAsync(id);
            if (targetVersion == null)
            {
                throw new SprmException(Common.Error.ErrorCode.DbDataNotFound, $@"Routing version id: {id} not found!");
            }
            RoutingVersion updatedVersion = update.ApplyUpdate(targetVersion);
            await _routingVersionDAO.UpdateAsync(updatedVersion, _headerData.JWTPayload.Subject);
            return;
        }
    }
}
