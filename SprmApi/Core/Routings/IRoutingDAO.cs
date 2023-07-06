using SprmApi.Core.Routings.DTOs;

namespace SprmApi.Core.Routings
{
    /// <summary>
    /// Routing DAO interface
    /// </summary>
    public interface IRoutingDAO
    {
        /// <summary>
        /// Create new Routing
        /// </summary>
        /// <param name="createDTO"></param>
        /// <param name="creator">Creator</param>
        /// <returns></returns>
        Task<Routing> InsertAsync(CreateRoutingDTO createDTO, string creator);

        /// <summary>
        /// Get routings by part id
        /// </summary>
        /// <param name="partId">Part id</param>
        /// <param name="includeVersion">Should return value include versions</param>
        /// <returns></returns>
        IQueryable<Routing> GetByPartId(long partId, bool includeVersion);

        /// <summary>
        /// Get routing by id
        /// </summary>
        /// <param name="routingId">Routing id</param>
        /// <returns></returns>
        Task<Routing?> GetByIdAsync(long routingId);

        /// <summary>
        /// Update a routing
        /// </summary>
        /// <param name="routing">Updated routing</param>
        /// <param name="modifier">Update user name</param>
        /// <returns></returns>
        Task<Routing> UpdateAsync(Routing routing, string modifier);
    }
}
