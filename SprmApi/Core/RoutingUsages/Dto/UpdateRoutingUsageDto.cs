using SprmApi.Common.Validations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SprmApi.Core.RoutingUsages.Dto
{
    /// <summary>
    /// 更新工藝路徑使用關係
    /// </summary>
    public class UpdateRoutingUsageDto
    {
        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 使用關係編號
        /// </summary>
        [NumberValidation]
        public string Number { get; set; } = string.Empty;

        /// <summary>
        /// 製程id
        /// </summary>
        [JsonRequired]
        public long ProcessId { get; set; }

        /// <summary>
        /// 自訂屬性
        /// </summary>
        public Dictionary<string, string> CustomValues { get; set; } = new();

        /// <summary>
        /// 更新entity資料
        /// </summary>
        /// <param name="usage"></param>
        /// <returns></returns>
        public RoutingUsage ApplyUpdate(RoutingUsage usage)
        {
            usage.Remarks = Remarks;
            usage.Number = Number;
            usage.CustomValues = JsonSerializer.SerializeToDocument(CustomValues);
            return usage;
        }
    }
}
