using SprmApi.Core.Processes.Dto;

namespace SprmApi.Core.Processes
{
    /// <summary>
    /// Process DAO interface
    /// </summary>
    public interface IProcessDao
    {
        /// <summary>
        /// Create a new process
        /// </summary>
        /// <param name="createDTO">Create DTO</param>
        /// <param name="creator">Creator</param>
        /// <returns></returns>
        Task<Process> Insert(CreateProcessDto createDTO, string creator);

        /// <summary>
        /// Get process by id
        /// </summary>
        /// <param name="id">Process id</param>
        /// <returns></returns>
        Task<Process?> GetAsync(long id);

        /// <summary>
        /// Get by search pattern
        /// </summary>
        /// <param name="pattern">Search pattern</param>
        /// <returns></returns>
        IQueryable<Process> GetByPattern(string? pattern);

        /// <summary>
        /// Get process by process number
        /// </summary>
        /// <param name="number">Process number</param>
        /// <returns></returns>
        Task<Process?> GetByNumberAsync(string number);

        /// <summary>
        /// Delete process by id
        /// </summary>
        /// <param name="id">Process id</param>
        /// <returns></returns>
        Task DeleteAsync(long id);

        /// <summary>
        /// Update process
        /// </summary>
        /// <param name="process">Process you want to update</param>
        /// <param name="updater">Updater</param>
        /// <returns></returns>
        Task UpdateAsync(Process process, string updater);
    }
}
