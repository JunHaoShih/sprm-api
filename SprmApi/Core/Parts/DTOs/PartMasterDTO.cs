using SprmApi.Common.DTOs;

namespace SprmApi.Core.Parts.DTOs
{
    /// <summary>
    /// 料件版本master DTO
    /// </summary>
    public class PartMasterDTO : BaseReturnDTO
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
        /// Parse entity to DTO
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        public static PartMasterDTO Parse(Part part)
        {
            var partDTO = new PartMasterDTO
            {
                Number = part.Number,
                Name = part.Name,
                ViewType = part.ViewType,
                Checkout = part.Checkout,
            };
            partDTO.Populate(part);
            return partDTO;
        }
    }
}
