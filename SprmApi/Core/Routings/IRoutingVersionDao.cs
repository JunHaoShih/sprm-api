namespace SprmApi.Core.Routings
{
    /// <summary>
    /// Routing version DAO interface
    /// </summary>
    public interface IRoutingVersionDao
    {
        /// <summary>
        /// Insert a new routing version
        /// </summary>
        /// <param name="routeVersion"></param>
        /// <param name="creator"></param>
        /// <returns></returns>
        Task<RoutingVersion> InsertAsync(RoutingVersion routeVersion, string creator);

        /// <summary>
        /// Delete routing version
        /// </summary>
        /// <param name="routeVersion">Routing version</param>
        /// <returns></returns>
        Task DeleteAsync(RoutingVersion routeVersion);

        /// <summary>
        /// Get all routing versions of specific master(routing)
        /// </summary>
        /// <param name="masterId">Routing id</param>
        /// <returns></returns>
        IQueryable<RoutingVersion> GetByMasterId(long masterId);

        /// <summary>
        /// Get routing version by id
        /// </summary>
        /// <param name="id">Routing version id</param>
        /// <returns></returns>
        Task<RoutingVersion?> GetAsync(long id);

        /// <summary>
        /// Update routing version by routing version id
        /// </summary>
        /// <param name="routingVersion">Updated routing version</param>
        /// <param name="updator">Update user name</param>
        /// <returns></returns>
        Task UpdateAsync(RoutingVersion routingVersion, string updator);

        /// <summary>
        /// Get latest version of specific routing
        /// </summary>
        /// <param name="masterId">Routing id</param>
        /// <returns></returns>
        Task<RoutingVersion?> GetLatest(long masterId);

        /// <summary>
        /// Get draft version of specific routing
        /// </summary>
        /// <param name="masterId"></param>
        /// <returns></returns>
        Task<RoutingVersion?> GetDraft(long masterId);
    }
}
