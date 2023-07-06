using SprmApi.Common.DTOs;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using System.Text.Json;

namespace SprmApi.Core.Routings.DTOs
{
    /// <summary>
    /// 工藝路徑版本DTO
    /// </summary>
    public class RoutingVersionDto : BaseReturnDto
    {
        /// <summary>
        /// 工藝路徑
        /// </summary>
        public RoutingMasterDto Master { get; set; } = null!;

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
        public Dictionary<string, string> CustomValues = new();

        /// <summary>
        /// Parse entity to DTO
        /// </summary>
        /// <param name="routingVersion"></param>
        /// <returns></returns>
        public static RoutingVersionDto Parse(RoutingVersion routingVersion)
        {
            if (routingVersion.Master == null)
            {
                throw new SprmException(ErrorCode.DbError, "Routing version master not found");
            }
            var dto = new RoutingVersionDto
            {
                Master = RoutingMasterDto.Parse(routingVersion.Master),
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
