using SprmApi.Core.ObjectTypes;

namespace SprmApi.Core.Customs
{
    /// <summary>
    /// Attribute link DAO interface
    /// </summary>
    public interface IAttributeLinkDAO
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
        /// Insert a new attribute link
        /// </summary>
        /// <param name="objectTypeId">Object type id</param>
        /// <param name="attributeId">Custom attribute id</param>
        /// <param name="creator">Creator's username</param>
        /// <returns></returns>
        Task<AttributeLink> Insert(SprmObjectType objectTypeId, long attributeId, string creator);

        /// <summary>
        /// Get attribute link by object type id and attribute id
        /// </summary>
        /// <param name="objectTypeId">Object type id</param>
        /// <param name="attributeId">Attribute id</param>
        /// <returns></returns>
        Task<AttributeLink?> Get(SprmObjectType objectTypeId, long attributeId);
    }
}
