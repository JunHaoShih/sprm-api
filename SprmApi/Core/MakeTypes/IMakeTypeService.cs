using SprmApi.Core.MakeTypes.DTOs;

namespace SprmApi.Core.MakeTypes
{
    /// <summary>
    /// Make type service interface
    /// </summary>
    public interface IMakeTypeService
    {
        /// <summary>
        /// Get all make types
        /// </summary>
        /// <returns></returns>
        IQueryable<MakeTypeDTO> GetAll();
    }
}
