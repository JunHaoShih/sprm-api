using SprmApi.Common.DTOs;

namespace SprmApi.Core.Parts.DTOs
{
    /// <summary>
    /// 零件
    /// </summary>
    public class PartDTO : BaseReturnDto
    {
        /// <summary>
        /// 料號
        /// </summary>
        public string Number { get; set; } = null!;

        /// <summary>
        /// 料件名稱
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 視圖類型
        /// </summary>
        public ViewType ViewType { get; set; }

        /// <summary>
        /// 是否出簽
        /// </summary>
        public bool Checkout { get; set; }

        /// <summary>
        /// 草稿版本id
        /// </summary>
        public long? DraftId { get; set; }

        /// <summary>
        /// 零件版本
        /// </summary>
        public PartVersionInfoDTO Version { get; set; } = null!;

        /// <summary>
        /// Parse entity to DTO
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        public static PartDTO? Parse(Part? part)
        {
            if (part == null)
            {
                return null;
            }
            var partDTO = new PartDTO
            {
                Number = part.Number,
                Name = part.Name,
                ViewType = part.ViewType,
                Checkout = part.Checkout,
            };
            partDTO.Populate(part);
            var draftVersion = part.PartVersions!.SingleOrDefault(version => version.IsDraft);
            if (draftVersion != null)
            {
                partDTO.DraftId = draftVersion.Id;
            }
            var latestVersion = part.PartVersions!
                .Where(version => version.IsLatest || version.IsDraft)
                .OrderByDescending(version => version.IsLatest)
                .First();
            partDTO.Version = PartVersionInfoDTO.Parse(latestVersion);
            return partDTO;
        }
    }
}
