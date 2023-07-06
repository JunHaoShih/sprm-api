using SprmApi.Core.Customs.DTOs;

namespace SprmApi.Core.Customs
{
    /// <summary>
    /// Custom attribute service interface
    /// </summary>
    public interface ICustomAttributeService
    {
        /// <summary>
        /// Get all custom attribute
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CustomAttribute>> GetAllAsync();

        /// <summary>
        /// Insert a new custom attribute
        /// </summary>
        /// <param name="dto">creation payload</param>
        /// <returns></returns>
        Task<CustomAttribute> InsertAsync(CreateCustomAttributeDto dto);

        /// <summary>
        /// Update custom attribute
        /// </summary>
        /// <param name="id">custom attribute id you want to update</param>
        /// <param name="attribute">Update data</param>
        /// <returns></returns>
        Task UpdateAsync(long id, UpdateCustomAttributeDto attribute);

        /// <summary>
        /// Delete custom attribute
        /// </summary>
        /// <param name="id">custom attribute id you want to delete</param>
        /// <returns></returns>
        Task DeleteAsync(long id);
    }
}
