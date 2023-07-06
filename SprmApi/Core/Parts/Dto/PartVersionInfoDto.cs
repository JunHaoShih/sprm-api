using System.Text.Json;
using SprmApi.Common.Dto;

namespace SprmApi.Core.Parts.Dto
{
    /// <summary>
    /// 零件版本DTO，PartDTO專用的版本DTO
    /// </summary>
    public class PartVersionInfoDto : BaseReturnDto
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
        /// <param name="partVersion"></param>
        /// <returns></returns>
        public static PartVersionInfoDto Parse(PartVersion partVersion)
        {
            var dto = new PartVersionInfoDto
            {
                MasterId = partVersion.MasterId,
                Version = partVersion.Version,
                IsLatest = partVersion.IsLatest,
                IsDraft = partVersion.IsDraft,
                CustomValues = JsonSerializer.Deserialize<Dictionary<string, string>>(partVersion.CustomValues)!,
            };
            dto.Populate(partVersion);
            return dto;
        }
    }
}
