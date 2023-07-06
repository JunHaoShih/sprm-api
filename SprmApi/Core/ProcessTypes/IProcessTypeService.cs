using SprmApi.Core.ProcessTypes.DTOs;

namespace SprmApi.Core.ProcessTypes
{
    /// <summary>
    /// Process type service interface
    /// </summary>
    public interface IProcessTypeService
    {
        /// <summary>
        /// Get all process types
        /// </summary>
        /// <returns></returns>
        IQueryable<ProcessTypeDto> GetAll();
    }
}
