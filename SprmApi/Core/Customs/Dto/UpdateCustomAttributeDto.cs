using SprmApi.Common.Validations;
using System.Text.Json.Serialization;

namespace SprmApi.Core.Customs.Dto
{
    /// <summary>
    /// Update DTO for custom attribute
    /// </summary>
    public class UpdateCustomAttributeDto
    {
        /// <summary>
        /// 自定屬性編號
        /// </summary>
        [JsonRequired]
        [NumberValidation]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 自定屬性名稱
        /// </summary>
        [JsonRequired]
        [NameValidation]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 自訂屬性類型
        /// </summary>
        [EnumValidation]
        [JsonRequired]
        public AttributeType AttributeType { get; set; }

        /// <summary>
        /// 自訂屬性顯示類型
        /// </summary>
        [EnumValidation]
        [JsonRequired]
        public DisplayType DisplayType { get; set; }

        /// <summary>
        /// 是否停用
        /// </summary>
        [JsonRequired]
        public bool IsDisabled { get; set; }

        /// <summary>
        /// 語系顯示
        /// </summary>
        [JsonRequired]
        public Dictionary<string, string> Languages { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// 自訂選項
        /// </summary>
        [JsonRequired]
        public IEnumerable<CustomOption> Options { get; set; } = Enumerable.Empty<CustomOption>();

        /// <summary>
        /// 備註
        /// </summary>
        [JsonRequired]
        public string? Remarks { get; set; }

        /// <summary>
        /// Apply update message to entity
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public CustomAttribute ApplyUpdate(CustomAttribute attribute)
        {
            attribute.Number = Number;
            attribute.Name = Name;
            attribute.AttributeType = AttributeType;
            attribute.DisplayType = DisplayType;
            attribute.IsDisabled = IsDisabled;
            attribute.Languages = Languages;
            attribute.Options = Options;
            attribute.Remarks = Remarks;
            return attribute;
        }
    }
}
