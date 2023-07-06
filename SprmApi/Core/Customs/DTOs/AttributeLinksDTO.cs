using SprmApi.Core.ObjectTypes;

namespace SprmApi.Core.Customs.DTOs
{
    /// <summary>
    /// Attribute links
    /// </summary>
    public class AttributeLinksDTO
    {
        /// <summary>
        /// Object type id
        /// </summary>
        public long ObjectTypeId { get; set; }

        /// <summary>
        /// Related custom attributes
        /// </summary>
        public IEnumerable<CustomAttributeDTO> Attributes { get; set; } = null!;

        /// <summary>
        /// Parse entities to DTO
        /// </summary>
        /// <param name="objectTypeId"></param>
        /// <param name="links"></param>
        /// <returns></returns>
        public static AttributeLinksDTO Parse(SprmObjectType objectTypeId, IEnumerable<AttributeLink> links)
        {
            var linksDTO = new AttributeLinksDTO();
            linksDTO.ObjectTypeId = (long)objectTypeId;
            linksDTO.Attributes = links.Select(link => CustomAttributeDTO.Parse(link.Attribute!));
            return linksDTO;
        }
    }
}
