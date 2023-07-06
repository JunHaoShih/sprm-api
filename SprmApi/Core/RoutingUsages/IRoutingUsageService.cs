using SprmApi.Core.RoutingUsages.DTOs;

namespace SprmApi.Core.RoutingUsages
{
    /// <summary>
    /// Routing usage service interface
    /// </summary>
    public interface IRoutingUsageService
    {
        /// <summary>
        /// Get all routing usage that belongs to specific routing version
        /// </summary>
        /// <param name="rootVersionId">Root routing version id</param>
        /// <returns></returns>
        Task<IEnumerable<RoutingUsageDTO>> GetByRootVersionIdAsync(long rootVersionId);

        /// <summary>
        /// Create a new routing usage
        /// </summary>
        /// <param name="createDto">Create data</param>
        /// <returns></returns>
        Task<RoutingUsageDTO> InsertAsync(CreateRoutingUsageDTO createDto);

        /// <summary>
        /// Delete routing usage by id
        /// </summary>
        /// <param name="id">Routing usage id</param>
        /// <returns></returns>
        Task DeleteAsync(long id);

        /// <summary>
        /// Update routing usage by id
        /// </summary>
        /// <param name="id">Routing usage id</param>
        /// <param name="updateData">Update data</param>
        /// <returns></returns>
        Task UpdateById(long id, UpdateRoutingUsageDTO updateData);
    }
}
