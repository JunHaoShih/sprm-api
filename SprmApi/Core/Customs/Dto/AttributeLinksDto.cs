using SprmApi.Core.ObjectTypes;

namespace SprmApi.Core.Customs.Dto
{
    /// <summary>
    /// Attribute links
    /// </summary>
    public class AttributeLinksDto
    {
        /// <summary>
        /// Object type id
        /// </summary>
        public long ObjectTypeId { get; set; }

        /// <summary>
        /// Related custom attributes
        /// </summary>
        public IEnumerable<CustomAttributeDto> Attributes { get; set; } = null!;

        /// <summary>
        /// Parse entities to DTO
        /// </summary>
        /// <param name="objectTypeId"></param>
        /// <param name="links"></param>
        /// <returns></returns>
        public static AttributeLinksDto Parse(SprmObjectType objectTypeId, IEnumerable<AttributeLink> links)
        {
            var linksDTO = new AttributeLinksDto();
            linksDTO.ObjectTypeId = (long)objectTypeId;
            linksDTO.Attributes = links.Select(link => CustomAttributeDto.Parse(link.Attribute!));
            return linksDTO;
        }
    }
}
