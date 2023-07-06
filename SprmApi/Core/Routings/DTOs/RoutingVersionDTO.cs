using SprmApi.Common.DTOs;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using System.Text.Json;

namespace SprmApi.Core.Routings.DTOs
{
    /// <summary>
    /// 工藝路徑版本DTO
    /// </summary>
    public class RoutingVersionDTO : BaseReturnDTO
    {
        /// <summary>
        /// 工藝路徑
        /// </summary>
        public RoutingMasterDTO Master { get; set; } = null!;

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
        public static RoutingVersionDTO Parse(RoutingVersion routingVersion)
        {
            if (routingVersion.Master == null)
            {
                throw new SPRMException(ErrorCode.DbError, "Routing version master not found");
            }
            var dto = new RoutingVersionDTO
            {
                Master = RoutingMasterDTO.Parse(routingVersion.Master),
                Version = routingVersion.Version,
                IsLatest = routingVersion.IsLatest,
                IsDraft = routingVersion.IsDraft,
                CustomValues = JsonSerializer.Deserialize<Dictionary<string, string>>(routingVersion.CustomValues)!,
            };
            dto.Populate(routingVersion);
            return dto;
        }

        /// <summary>
        /// 工藝路徑master資料
        /// </summary>
        public class RoutingMasterDTO : BaseReturnDTO
        {
            /// <summary>
            /// 工藝路徑名稱
            /// </summary>
            public string Name { get; set; } = null!;

            /// <summary>
            /// 是否出簽
            /// </summary>
            public bool Checkout { get; set; }

            /// <summary>
            /// Parse entity to DTO
            /// </summary>
            /// <param name="routing"></param>
            /// <returns></returns>
            public static RoutingMasterDTO Parse(Routing routing)
            {
                var dto = new RoutingMasterDTO
                {
                    Id = routing.Id,
                    Name = routing.Name,
                    Checkout = routing.Checkout,
                };
                dto.Populate(routing);
                return dto;
            }
        }
    }
}
