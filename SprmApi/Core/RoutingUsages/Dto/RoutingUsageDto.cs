using System.Text.Json;
using SprmApi.Common.Dto;
using SprmCommon.Error;
using SprmCommon.Exceptions;

namespace SprmApi.Core.RoutingUsages.Dto
{
    /// <summary>
    /// 工藝路徑使用關係DTO
    /// </summary>
    public class RoutingUsageDto : BaseReturnDto
    {
        /// <summary>
        /// 使用關係編號
        /// </summary>
        public string Number { get; set; } = string.Empty;

        /// <summary>
        /// 所屬工藝路徑版本id
        /// </summary>
        public long RootVersionId { get; set; }

        /// <summary>
        /// 父項使用關係id
        /// </summary>
        public long? ParentUsageId { get; set; }

        /// <summary>
        /// 製程id
        /// </summary>
        public long ProcessId { get; set; }

        /// <summary>
        /// 製程編號
        /// </summary>
        public string ProcessNumber { get; set; } = string.Empty;

        /// <summary>
        /// 製程名稱
        /// </summary>
        public string ProcessName { get; set; } = string.Empty;

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        public Dictionary<string, string> CustomValues { get; set; } = new();

        /// <summary>
        /// Parse entity to DTO
        /// </summary>
        /// <param name="routingUsage"></param>
        /// <returns></returns>
        public static RoutingUsageDto Parse(RoutingUsage routingUsage)
        {
            if (routingUsage.Process == null)
            {
                throw new SprmException(ErrorCode.Error, "Routing usage process not found!");
            }
            RoutingUsageDto dto = new RoutingUsageDto
            {
                Number = routingUsage.Number,
                RootVersionId = routingUsage.RootVersionId,
                ParentUsageId = routingUsage.ParentUsageId,
                ProcessId = routingUsage.ProcessId,
                ProcessNumber = routingUsage.Process.Number,
                ProcessName = routingUsage.Process.Name,
                CustomValues = JsonSerializer.Deserialize<Dictionary<string, string>>(routingUsage.CustomValues)!,
            };
            dto.Populate(routingUsage);
            return dto;
        }
    }
}
