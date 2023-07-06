using SprmApi.Core.Parts.DTOs;

namespace SprmApi.Core.Parts
{
    /// <summary>
    /// Part DAO interface
    /// </summary>
    public interface IPartDAO
    {
        /// <summary>
        /// Get part by id
        /// </summary>
        /// <param name="id">part id</param>
        /// <returns></returns>
        Task<Part?> GetByIdAsync(long id);

        /// <summary>
        /// Get part by part number
        /// </summary>
        /// <param name="number">Part number</param>
        /// <returns></returns>
        Task<Part?> GetByNumberAsync(string number);

        /// <summary>
        /// Get by pattern
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        IQueryable<Part> GetByPatternAsync(string? pattern);

        /// <summary>
        /// Create a new part
        /// </summary>
        /// <param name="createPartDTO"></param>
        /// <param name="creator">Create user name</param>
        /// <returns></returns>
        Task<Part> InsertAsync(CreatePartDto createPartDTO, string creator);

        /// <summary>
        /// Delete a part
        /// </summary>
        /// <param name="id">part id</param>
        Task DeleteAsync(long id);

        /// <summary>
        /// Update a part
        /// </summary>
        /// <param name="part">Updated part</param>
        /// <param name="modifier">Update user name</param>
        /// <returns></returns>
        Task<Part> UpdateAsync(Part part, string modifier);
    }
}
