using Newtonsoft.Json;
using SprmApi.Common.Validations;

namespace SprmApi.Core.PartUsages.DTOs
{
    /// <summary>
    /// DTO for creating part usages
    /// </summary>
    public class CreatePartUsagesDTO
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
        public IEnumerable<CreatePartUsageChildDTO> Children { get; set; } = Enumerable.Empty<CreatePartUsageChildDTO>();
    }

    /// <summary>
    /// Child part and quantity
    /// </summary>
    public class CreatePartUsageChildDTO
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
        public static CreatePartUsageChildDTO Parse(PartUsage partUsage)
        {
            return new CreatePartUsageChildDTO
            {
                PartId = partUsage.ChildId,
                Quantity = partUsage.Quantity,
                Remarks = partUsage.Remarks,
                CustomValues = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(partUsage.CustomValues)!,
            };
        }
    }
}
