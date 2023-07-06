using SprmApi.Common.Paginations;
using SprmApi.Core.Routings.DTOs;

namespace SprmApi.Core.Routings
{
    /// <summary>
    /// Routing version service interface
    /// </summary>
    public interface IRoutingVersionService
    {

        /// <summary>
        /// Get all routing versions of specific master(routing)
        /// </summary>
        /// <param name="masterId">Routing id</param>
        /// <param name="input">Pagination data</param>
        /// <returns></returns>
        Task<OffsetPagination<RoutingVersionDto>> GetByMasterId(long masterId, OffsetPaginationInput input);

        /// <summary>
        /// Get routing version by id
        /// </summary>
        /// <param name="id">Routing version id</param>
        /// <returns></returns>
        Task<RoutingVersionDto?> GetAsync(long id);

        /// <summary>
        /// Update routing version
        /// </summary>
        /// <param name="id">Routing version id</param>
        /// <param name="update">Update data</param>
        /// <returns></returns>
        Task UpdateAsync(long id, UpdateRoutingVersionDto update);
    }
}
