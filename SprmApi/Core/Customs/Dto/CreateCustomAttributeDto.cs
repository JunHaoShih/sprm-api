using Newtonsoft.Json;
using SprmApi.Common.Validations;

namespace SprmApi.Core.Customs.Dto
{
    /// <summary>
    /// Custom attribute creation payload
    /// </summary>
    public class CreateCustomAttributeDto
    {
        /// <summary>
        /// Custom attribute number
        /// </summary>
        [JsonRequired]
        [NumberValidation]
        public string Number { get; set; } = null!;

        /// <summary>
        /// Custom attribute name
        /// </summary>
        [JsonRequired]
        [NameValidation]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 自訂屬性類型
        /// </summary>
        [EnumValidation]
        [JsonProperty(Required = Required.Always)]
        public AttributeType AttributeType { get; set; }

        /// <summary>
        /// 自訂屬性顯示類型
        /// </summary>
        [EnumValidation]
        [JsonProperty(Required = Required.Always)]
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
        public string? Remarks { get; set; }

        /// <summary>
        /// Parse DTO to entity
        /// </summary>
        /// <returns></returns>
        public CustomAttribute ToEntity()
        {
            return new CustomAttribute
            {
                Number = this.Number,
                Name = this.Name,
                AttributeType = this.AttributeType,
                DisplayType = this.DisplayType,
                IsDisabled = this.IsDisabled,
                Languages = this.Languages,
                Options = this.Options,
                Remarks = this.Remarks,
            };
        }
    }
}
