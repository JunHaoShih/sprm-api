
using System.Text.Json;

namespace SprmApi.Core.Parts.DTOs
{
    /// <summary>
    /// 建立料件版本DTO
    /// </summary>
    public class CreatePartVersionDTO
    {
        /// <summary>
        /// 料件id
        /// </summary>
        public long MasterId { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// 是否為最新
        /// </summary>
        public bool IsLatest { get; set; }

        /// <summary>
        /// 是否為草稿
        /// </summary>
        public bool IsDraft { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        public Dictionary<string, string> CustomValues { get; set; } = new();

        /// <summary>
        /// Parse to entity
        /// </summary>
        /// <returns></returns>
        public PartVersion ToEntity()
        {
            return new PartVersion
            {
                MasterId = MasterId,
                Version = Version,
                IsLatest = IsLatest,
                IsDraft = IsDraft,
                Remarks = Remarks,
                CustomValues = JsonSerializer.SerializeToDocument(CustomValues),
            };
        }

        /// <summary>
        /// Parse entity to create DTO
        /// </summary>
        /// <param name="version">entity</param>
        /// <returns></returns>
        public static CreatePartVersionDTO Parse(PartVersion version)
        {
            return new CreatePartVersionDTO
            {
                MasterId = version.MasterId,
                Version = version.Version,
                IsLatest = version.IsLatest,
                IsDraft= version.IsDraft,
                Remarks = version.Remarks,
                CustomValues = JsonSerializer.Deserialize<Dictionary<string, string>>(version.CustomValues)!,
            };
        }
    }
}
