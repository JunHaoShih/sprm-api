using SprmApi.Core.PartUsages.DTOs;

namespace SprmApi.Core.PartUsages
{
    /// <summary>
    /// Part usage service interface
    /// </summary>
    public interface IPartUsageService
    {
        /// <summary>
        /// Create multiple part usages
        /// </summary>
        /// <param name="usagesDTO">Create DTO</param>
        /// <returns></returns>
        Task<IEnumerable<PartUsage>> InsertAsync(CreatePartUsagesDTO usagesDTO);

        /// <summary>
        /// Get all parts a part version uses
        /// </summary>
        /// <param name="parentPartVersionId">Parent part version id</param>
        /// <returns></returns>
        Task<IEnumerable<PartUsage>> GetByPartVersionIdAsync(long parentPartVersionId);

        /// <summary>
        /// Get part usage by id
        /// </summary>
        /// <param name="id">Part usage id</param>
        /// <returns></returns>
        Task<PartUsage?> GetById(long id);

        /// <summary>
        /// Delete part usage by id
        /// </summary>
        /// <param name="id">Part usage id</param>
        /// <returns></returns>
        Task DeleteById(long id);

        /// <summary>
        /// Update part usage by id
        /// </summary>
        /// <param name="id">Part usage id</param>
        /// <param name="updateData">Update data</param>
        /// <returns></returns>
        Task UpdateById(long id, UpdatePartUsageDTO updateData);
    }
}
