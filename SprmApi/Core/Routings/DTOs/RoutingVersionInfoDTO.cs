using System.Text.Json;
using SprmApi.Common.DTOs;

namespace SprmApi.Core.Routings.DTOs
{
    /// <summary>
    /// 工藝路徑版本DTO，(只可以在RoutingDto使用)
    /// </summary>
    public class RoutingVersionInfoDto : BaseReturnDto
    {
        /// <summary>
        /// 零件id
        /// </summary>
        public long MasterId { get; set; }

        /// <summary>
        /// 零件修訂版本號
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// 是否為最新版
        /// </summary>
        public bool IsLatest { get; set; }

        /// <summary>
        /// 是否為草稿
        /// </summary>
        public bool IsDraft { get; set; }

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        public Dictionary<string, string> CustomValues { get; set; } = new();

        /// <summary>
        /// Parse entity to DTO
        /// </summary>
        /// <param name="routingVersion"></param>
        /// <returns></returns>
        public static RoutingVersionInfoDto Parse(RoutingVersion routingVersion)
        {
            var dto = new RoutingVersionInfoDto
            {
                MasterId = routingVersion.MasterId,
                Version = routingVersion.Version,
                IsLatest = routingVersion.IsLatest,
                IsDraft = routingVersion.IsDraft,
                CustomValues = JsonSerializer.Deserialize<Dictionary<string, string>>(routingVersion.CustomValues)!,
            };
            dto.Populate(routingVersion);
            return dto;
        }
    }
}
