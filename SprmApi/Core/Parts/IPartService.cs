using SprmApi.Common.Paginations;
using SprmApi.Core.Parts.Dto;

namespace SprmApi.Core.Parts
{
    /// <summary>
    /// Part service interface
    /// </summary>
    public interface IPartService
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
        /// <param name="input">分頁資訊</param>
        /// <returns></returns>
        Task<IEnumerable<Part>> GetByPatternAsync(string? pattern, OffsetPaginationInput input);

        /// <summary>
        /// Create a new part
        /// </summary>
        /// <param name="createPartDTO"></param>
        /// <returns></returns>
        Task<Part> InsertAsync(CreatePartDto createPartDTO);

        /// <summary>
        /// Delete a part
        /// </summary>
        /// <param name="id">Part id</param>
        Task DeleteAsync(long id);

        /// <summary>
        /// Check out part
        /// </summary>
        /// <param name="partId">Part id</param>
        /// <param name="versionId">The version id you want to check out</param>
        /// <returns></returns>
        Task<Part> CheckOutAsync(long partId, long? versionId = null);

        /// <summary>
        /// Check in part
        /// </summary>
        /// <param name="partId">Part id</param>
        /// <returns></returns>
        Task<Part> CheckInAsync(long partId);

        /// <summary>
        /// Discard current checkout part version
        /// </summary>
        /// <param name="partId">Part id</param>
        /// <returns></returns>
        Task<Part> DiscardAsync(long partId);
    }
}
