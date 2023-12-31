﻿using SprmApi.Common.Dto;
using SprmApi.Core.Parts.Dto;
using System.Text.Json;

namespace SprmApi.Core.PartUsages.Dto
{
    /// <summary>
    /// Part usage DTO
    /// </summary>
    public class PartUsageUsesDto : BaseReturnDto
    {
        /// <summary>
        /// The part version id which child part is used by
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// The part which parent part version uses
        /// </summary>
        public PartDto Child { get; set; } = null!;

        /// <summary>
        /// Child part quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Number of child's child part
        /// </summary>
        public int SubChildCount { get; set; }

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        public Dictionary<string, string> CustomValues { get; set; } = new();

        /// <summary>
        /// Parse entity to DTO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PartUsageUsesDto? Parse(PartUsage? entity)
        {
            if (entity == null) return null;
            var dto = new PartUsageUsesDto()
            {
                ParentId = entity.ParentId,
                Child = PartDto.Parse(entity.Child)!,
                Quantity = entity.Quantity,
                SubChildCount = entity.Child!.PartVersions!.First().PartUsages!.Count,
                CustomValues = JsonSerializer.Deserialize<Dictionary<string, string>>(entity.CustomValues)!,
            };
            dto.Populate(entity);
            return dto;
        }
    }
}
