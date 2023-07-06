using SprmApi.Common.Paginations;
using SprmApi.Core.Processes.Dto;

namespace SprmApi.Core.Processes
{
    /// <summary>
    /// Process service interface
    /// </summary>
    public interface IProcessService
    {
        /// <summary>
        /// Create a new process
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        Task<ProcessDto> InsertAsync(CreateProcessDto createDTO);

        /// <summary>
        /// Get process by id
        /// </summary>
        /// <param name="id">Process is</param>
        /// <returns></returns>
        Task<ProcessDto?> GetAsync(long id);

        /// <summary>
        /// Search process by pattern
        /// </summary>
        /// <param name="pattern">Search pattern</param>
        /// <param name="input">Offset pagination input data</param>
        /// <returns></returns>
        OffsetPagination<ProcessDto> GetByPattern(string? pattern, OffsetPaginationInput input);

        /// <summary>
        /// Delete process by id
        /// </summary>
        /// <param name="id">Process id</param>
        /// <returns></returns>
        Task DeleteAsync(long id);

        /// <summary>
        /// Update process by id
        /// </summary>
        /// <param name="id">Process id</param>
        /// <param name="updateDTO">Update data</param>
        /// <returns></returns>
        Task UpdateAsync(long id, UpdateProcessDto updateDTO);
    }
}
