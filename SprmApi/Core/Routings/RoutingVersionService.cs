﻿using SprmApi.Common.Paginations;
using SprmApi.Core.Routings.Dto;
using SprmApi.MiddleWares;
using SprmCommon.Error;
using SprmCommon.Exceptions;

namespace SprmApi.Core.Routings
{
    /// <summary>
    /// Routing version service
    /// </summary>
    public class RoutingVersionService : IRoutingVersionService
    {
        private readonly IRoutingDao _routingDAO;

        private readonly IRoutingVersionDao _routingVersionDAO;

        private readonly HeaderData _headerData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="routingDAO"></param>
        /// <param name="routingVersionDAO"></param>
        /// <param name="headerData"></param>
        public RoutingVersionService(
            IRoutingDao routingDAO,
            IRoutingVersionDao routingVersionDAO,
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
                throw new SprmException(ErrorCode.DbDataNotFound, $@"Routing id: {masterId} not found!");
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
                throw new SprmException(ErrorCode.DbDataNotFound, $@"Routing version id: {id} not found!");
            }
            RoutingVersion updatedVersion = update.ApplyUpdate(targetVersion);
            await _routingVersionDAO.UpdateAsync(updatedVersion, _headerData.JWTPayload.Subject);
        }
    }
}
