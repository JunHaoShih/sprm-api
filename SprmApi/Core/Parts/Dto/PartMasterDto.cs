﻿using SprmApi.Common.Dto;

namespace SprmApi.Core.Parts.Dto
{
    /// <summary>
    /// 料件版本master DTO
    /// </summary>
    public class PartMasterDto : BaseReturnDto
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
        public static PartMasterDto Parse(Part part)
        {
            var partDTO = new PartMasterDto
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
