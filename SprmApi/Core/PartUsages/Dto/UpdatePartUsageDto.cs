﻿using SprmApi.Common.Validations;
using System.Text.Json.Serialization;

namespace SprmApi.Core.PartUsages.Dto
{
    /// <summary>
    /// 使用關係更新DTO
    /// </summary>
    public class UpdatePartUsageDto
    {
        /// <summary>
        /// 備註
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 使用數量
        /// </summary>
        [JsonRequired]
        [IntMinMaxValidation(MinValue = 0)]
        public int Quantity { get; set; }

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        [JsonRequired]
        public Dictionary<string, string> CustomValues { get; set; } = new();

        /// <summary>
        /// 更新entity資料
        /// </summary>
        /// <param name="usage"></param>
        /// <returns></returns>
        public PartUsage ApplyUpdate(PartUsage usage)
        {
            usage.Remarks = Remarks;
            usage.Quantity = Quantity;
            usage.CustomValues = System.Text.Json.JsonSerializer.SerializeToDocument(CustomValues);
            return usage;
        }
    }
}
