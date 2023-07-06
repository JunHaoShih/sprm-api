using SprmApi.Common.Dto;

namespace SprmApi.Core.Routings.Dto
{
    /// <summary>
    /// 工藝路徑master資料，(只可在RoutingVersionDto使用)
    /// </summary>
    public class RoutingMasterDto : BaseReturnDto
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
        public static RoutingMasterDto Parse(Routing routing)
        {
            var dto = new RoutingMasterDto
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
