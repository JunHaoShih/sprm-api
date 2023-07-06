using SprmApi.Core.ProcessTypes.Dto;

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
