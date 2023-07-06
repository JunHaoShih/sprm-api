using Newtonsoft.Json;
using SprmApi.Common.Validations;
using SprmApi.Core.ObjectTypes;

namespace SprmApi.Core.Customs.DTOs
{
    /// <summary>
    /// 建立attribute links的DTO
    /// </summary>
    public class CreateAttributeLinksDto
    {
        /// <summary>
        /// 物件類別id
        /// </summary>
        [JsonRequired]
        [EnumValidation]
        public SprmObjectType ObjectTypeId { get; set; }

        /// <summary>
        /// 自訂屬性id
        /// </summary>
        [JsonRequired]
        public IEnumerable<long> AttributeIds { get; set; } = null!;
    }
}
