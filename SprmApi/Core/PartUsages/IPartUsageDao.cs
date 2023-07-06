using SprmApi.Core.PartUsages.Dto;

namespace SprmApi.Core.PartUsages
{
    /// <summary>
    /// Part usage DAO interface
    /// </summary>
    public interface IPartUsageDao
    {
        /// <summary>
        /// Insert a new part usage
        /// </summary>
        /// <param name="parentPartVersionId">Parent part version id</param>
        /// <param name="childDTO">Child part</param>
        /// <param name="creator">Who create this usage</param>
        /// <returns></returns>
        Task<PartUsage> InsertAsync(long parentPartVersionId, CreatePartUsageChildDto childDTO, string creator);

        /// <summary>
        /// Get part usage by parent part version id and child part id
        /// </summary>
        /// <param name="parentPartVersionId">Parent part version id</param>
        /// <param name="childPartId">Child part id</param>
        /// <returns></returns>
        Task<PartUsage?> GetAsync(long parentPartVersionId, long childPartId);

        /// <summary>
        /// Get part usage by id
        /// </summary>
        /// <param name="id">Part usage id</param>
        /// <param name="includeSubChildren">If it should include sub children(Will performance hit)</param>
        /// <returns></returns>
        Task<PartUsage?> GetAsync(long id, bool includeSubChildren);

        /// <summary>
        /// Get all parts a part version uses
        /// </summary>
        /// <param name="parentPartVersionId">Parent part version id</param>
        /// <param name="includeSubChildren">If it should include sub children(Will performance hit)</param>
        /// <returns></returns>
        Task<IEnumerable<PartUsage>> GetByPartVersionIdAsync(long parentPartVersionId, bool includeSubChildren);

        /// <summary>
        /// Delete by part usage id
        /// </summary>
        /// <param name="id">Part usage id</param>
        /// <returns></returns>
        Task DeleteAsync(long id);

        /// <summary>
        /// Update part usage
        /// </summary>\
        /// <param name="entity">Update data</param>
        /// <param name="updator">Update user</param>
        /// <returns></returns>
        Task UpdateAsync(PartUsage entity, string updator);
    }
}
