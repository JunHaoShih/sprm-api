using SprmApi.Common.DTOs;

namespace SprmApi.Core.Customs.DTOs
{
    /// <summary>
    /// 自定屬性
    /// </summary>
    public class CustomAttributeDto : BaseReturnDto
    {
        /// <summary>
        /// 自定屬性編號
        /// </summary>
        public string Number { get; set; } = null!;

        /// <summary>
        /// 自定屬性名稱
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 自訂屬性類型
        /// </summary>
        public AttributeType AttributeType { get; set; }

        /// <summary>
        /// 自訂屬性顯示類型
        /// </summary>
        public DisplayType DisplayType { get; set; }

        /// <summary>
        /// 是否停用
        /// </summary>
        public bool IsDisabled { get; set; }

        /// <summary>
        /// 語系顯示
        /// </summary>
        public Dictionary<string, string> Languages { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// 自訂選項
        /// </summary>
        public IEnumerable<CustomOption> Options { get; set; } = Enumerable.Empty<CustomOption>();

        /// <summary>
        /// Parse entity to DTO
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static CustomAttributeDto Parse(CustomAttribute attribute)
        {
            var dto = new CustomAttributeDto
            {
                Number = attribute.Number,
                Name = attribute.Name,
                AttributeType = attribute.AttributeType,
                DisplayType = attribute.DisplayType,
                IsDisabled = attribute.IsDisabled,
                Languages = attribute.Languages,
                Options = attribute.Options,
            };
            dto.Populate(attribute);
            return dto;
        }
    }
}
