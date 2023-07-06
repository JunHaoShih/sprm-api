using SprmApi.Core.Customs.DTOs;

namespace SprmApi.Core.Customs
{
    /// <summary>
    /// Custom attribute DAO interface
    /// </summary>
    public interface ICustomAttributeDAO
    {
        /// <summary>
        /// Get all custom attributes
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CustomAttribute>> GetAllAsync();

        /// <summary>
        /// Insert a new custom attribute
        /// </summary>
        /// <param name="dto">creation payload</param>
        /// <param name="creator">creator username</param>
        /// <returns></returns>
        Task<CustomAttribute> InsertAsync(CreateCustomAttributeDto dto, string creator);

        /// <summary>
        /// Update custom attribute
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="updater"></param>
        /// <returns></returns>
        Task UpdateAsync(CustomAttribute attribute, string updater);

        /// <summary>
        /// Get custom attribute by id
        /// </summary>
        /// <param name="id">custom attribute id</param>
        /// <returns></returns>
        Task<CustomAttribute?> GetByIdAsync(long id);

        /// <summary>
        /// Get custom attribute by number
        /// </summary>
        /// <param name="number">custom attribute number</param>
        /// <returns></returns>
        Task<CustomAttribute?> GetByNumberAsync(string number);

        /// <summary>
        /// Delete custom attribute by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(long id);
    }
}
