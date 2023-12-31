﻿using SprmApi.Core.RoutingUsages.Dto;

namespace SprmApi.Core.RoutingUsages
{
    /// <summary>
    /// Routing usage DAO interface
    /// </summary>
    public interface IRoutingUsageDao
    {
        /// <summary>
        /// Insert new routing usage
        /// </summary>
        /// <param name="createDto"></param>
        /// <param name="creater"></param>
        /// <returns></returns>
        Task<RoutingUsage> InsertAsync(CreateRoutingUsageDto createDto, string creater);

        /// <summary>
        /// Get all routing usages by root routing version id
        /// </summary>
        /// <param name="rootId">Root routing version id</param>
        /// <returns></returns>
        IQueryable<RoutingUsage> GetByRootVersionId(long rootId);

        /// <summary>
        /// Get routing usages by root routing version id and parent usage id
        /// </summary>
        /// <param name="rootId"></param>
        /// <param name="parentUsageId"></param>
        /// <returns></returns>
        IQueryable<RoutingUsage> GetByRootVersionIdAndParentUsageId(long rootId, long? parentUsageId);

        /// <summary>
        /// Delete routing usage by id
        /// </summary>
        /// <param name="id">Routing usage id</param>
        /// <returns></returns>
        Task DeleteAsync(long id);

        /// <summary>
        /// Get routing usage by id
        /// </summary>
        /// <param name="id">Routing usage id</param>
        /// <returns></returns>
        Task<RoutingUsage?> GetAsync(long id);

        /// <summary>
        /// Update routing usage
        /// </summary>\
        /// <param name="entity">Update data</param>
        /// <param name="updator">Update user</param>
        /// <returns></returns>
        Task UpdateAsync(RoutingUsage entity, string updator);
    }
}
