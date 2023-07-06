using Newtonsoft.Json;
using SprmApi.Common.Validations;

namespace SprmApi.Core.Routings.DTOs
{
    /// <summary>
    /// 工藝路徑建立DTO
    /// </summary>
    public class CreateRoutingDto
    {
        /// <summary>
        /// 工藝路徑所屬料件
        /// </summary>
        public long PartId { get; set; }

        /// <summary>
        /// 工藝路徑名稱
        /// </summary>
        [JsonRequired]
        [NameValidation]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        public Dictionary<string, string> CustomValues { get; set; } = new();

        /// <summary>
        /// DTO to entity
        /// </summary>
        /// <returns></returns>
        public Routing ToEntity()
        {
            return new Routing
            {
                Name = Name,
                Remarks = Remarks,
                PartId = PartId,
            };
        }
    }
}
