using SprmApi.Common.Validations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SprmApi.Core.PartUsages.Dto
{
    /// <summary>
    /// DTO for creating part usages
    /// </summary>
    public class CreatePartUsagesDto
    {
        /// <summary>
        /// Parent part version id
        /// </summary>
        [JsonRequired]
        public long PartVersionId { get; set; }

        /// <summary>
        /// Child part ids
        /// </summary>
        [JsonRequired]
        public IEnumerable<CreatePartUsageChildDto> Children { get; set; } = Enumerable.Empty<CreatePartUsageChildDto>();
    }

    /// <summary>
    /// Child part and quantity
    /// </summary>
    public class CreatePartUsageChildDto
    {
        /// <summary>
        /// Child part id
        /// </summary>
        [JsonRequired]
        public long PartId { get; set; }

        /// <summary>
        /// Child part quantity
        /// </summary>
        [JsonRequired]
        [IntMinMaxValidation(MinValue = 0)]
        public int Quantity { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        public Dictionary<string, string> CustomValues { get; set; } = new();

        /// <summary>
        /// 將entity轉換成DTO
        /// </summary>
        /// <param name="partUsage"></param>
        /// <returns></returns>
        public static CreatePartUsageChildDto Parse(PartUsage partUsage)
        {
            return new CreatePartUsageChildDto
            {
                PartId = partUsage.ChildId,
                Quantity = partUsage.Quantity,
                Remarks = partUsage.Remarks,
                CustomValues = JsonSerializer.Deserialize<Dictionary<string, string>>(partUsage.CustomValues)!,
            };
        }
    }
}
