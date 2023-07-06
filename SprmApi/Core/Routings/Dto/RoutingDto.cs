using SprmApi.Common.Dto;

namespace SprmApi.Core.Routings.Dto
{
    /// <summary>
    /// 工藝路徑DTO
    /// </summary>
    public class RoutingDto : BaseReturnDto
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
        public RoutingVersionInfoDto Version { get; set; } = null!;

        /// <summary>
        /// Parse entity to DTO
        /// </summary>
        /// <param name="routing"></param>
        /// <param name="version"></param>
        /// <param name="draft"></param>
        /// <returns></returns>
        public static RoutingDto Parse(Routing routing, RoutingVersion version, RoutingVersion? draft = null)
        {
            var routingDTO = new RoutingDto
            {
                PartId = routing.PartId,
                Name = routing.Name,
                Checkout = routing.Checkout,
                Version = RoutingVersionInfoDto.Parse(version),
            };
            routingDTO.Populate(routing);
            if (draft != null)
            {
                routingDTO.DraftId = draft.Id;
            }
            return routingDTO;
        }

        
    }
}
