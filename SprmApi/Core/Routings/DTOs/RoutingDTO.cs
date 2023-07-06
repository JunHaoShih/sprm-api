using SprmApi.Common.DTOs;
using System.Text.Json;

namespace SprmApi.Core.Routings.DTOs
{
    /// <summary>
    /// 工藝路徑DTO
    /// </summary>
    public class RoutingDTO : BaseReturnDTO
    {
        /// <summary>
        /// 料號id
        /// </summary>
        public long PartId { get; set; }

        /// <summary>
        /// 料件名稱
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 是否出簽
        /// </summary>
        public bool Checkout { get; set; }

        /// <summary>
        /// 草稿版本id
        /// </summary>
        public long? DraftId { get; set; }

        /// <summary>
        /// 最新版本
        /// </summary>
        public RoutingVersionInfoDTO Version { get; set; } = null!;

        /// <summary>
        /// Parse entity to DTO
        /// </summary>
        /// <param name="routing"></param>
        /// <param name="version"></param>
        /// <param name="draft"></param>
        /// <returns></returns>
        public static RoutingDTO Parse(Routing routing, RoutingVersion version, RoutingVersion? draft = null)
        {
            var routingDTO = new RoutingDTO
            {
                PartId = routing.PartId,
                Name = routing.Name,
                Checkout = routing.Checkout,
                Version = RoutingVersionInfoDTO.Parse(version),
            };
            routingDTO.Populate(routing);
            if (draft != null)
            {
                routingDTO.DraftId = draft.Id;
            }
            return routingDTO;
        }

        /// <summary>
        /// 工藝路徑版本DTO
        /// </summary>
        public class RoutingVersionInfoDTO : BaseReturnDTO
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
            public Dictionary<string, string> CustomValues = new();

            /// <summary>
            /// Parse entity to DTO
            /// </summary>
            /// <param name="routingVersion"></param>
            /// <returns></returns>
            public static RoutingVersionInfoDTO Parse(RoutingVersion routingVersion)
            {
                var dto = new RoutingVersionInfoDTO
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
}
