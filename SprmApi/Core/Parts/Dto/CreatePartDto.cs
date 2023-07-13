using System.Text.Json;
using System.Text.Json.Serialization;
using SprmApi.Common.Validations;

namespace SprmApi.Core.Parts.Dto
{
    /// <summary>
    /// 建立料件DTO
    /// </summary>
    public class CreatePartDto
    {
        /// <summary>
        /// Part number
        /// </summary>
        [JsonRequired]
        [NumberValidation]
        public string Number { get; set; } = null!;

        /// <summary>
        /// Part name
        /// </summary>
        [JsonRequired]
        [NameValidation]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 視圖類型
        /// </summary>
        [EnumValidation]
        public ViewType ViewType { get; set; }

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        public Dictionary<string, string> CustomValues { get; set; } = new();

        /// <summary>
        /// Parse to entity
        /// </summary>
        /// <returns></returns>
        public Part ToEntity()
        {
            return JsonSerializer.Deserialize<Part>(JsonSerializer.Serialize(this))!;
        }
    }
}
