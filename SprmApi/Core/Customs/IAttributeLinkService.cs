using SprmApi.Core.Customs.Dto;
using SprmApi.Core.ObjectTypes;

namespace SprmApi.Core.Customs
{
    /// <summary>
    /// Attribute link service interface
    /// </summary>
    public interface IAttributeLinkService
    {
        /// <summary>
        /// Get attribute links of specific object type
        /// </summary>
        /// <param name="objectTypeId">target object type id</param>
        /// <returns></returns>
        Task<IEnumerable<AttributeLink>> GetByObjectTypeIdAsync(SprmObjectType objectTypeId);

        /// <summary>
        /// Delete attribute link by id (This method will include custom attributes)
        /// </summary>
        /// <param name="id">Attribute link id you want to delete</param>
        /// <returns></returns>
        Task DeleteAsync(long id);

        /// <summary>
        /// Delete a group of attribute links
        /// </summary>
        /// <param name="deleteDTO"></param>
        /// <returns></returns>
        Task DeleteAsync(DeleteAttributeLinksDto deleteDTO);

        /// <summary>
        /// Insert a group of attribute links
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns></returns>
        Task<IEnumerable<AttributeLink>> InsertAsync(CreateAttributeLinksDto createDTO);
    }
}
