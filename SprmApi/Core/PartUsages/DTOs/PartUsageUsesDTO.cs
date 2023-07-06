using SprmApi.Common.DTOs;
using SprmApi.Core.Parts.DTOs;
using System.Text.Json;

namespace SprmApi.Core.PartUsages.DTOs
{
    /// <summary>
    /// Part usage DTO
    /// </summary>
    public class PartUsageUsesDTO : BaseReturnDTO
    {
        /// <summary>
        /// The part version id which child part is used by
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// The part which parent part version uses
        /// </summary>
        public PartDTO Child { get; set; } = null!;

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
        public Dictionary<string, string> CustomValues = new();

        /// <summary>
        /// Parse entity to DTO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static PartUsageUsesDTO? Parse(PartUsage? entity)
        {
            if (entity == null) return null;
            var dto = new PartUsageUsesDTO()
            {
                ParentId = entity.ParentId,
                Child = PartDTO.Parse(entity.Child)!,
                Quantity = entity.Quantity,
                SubChildCount = entity.Child!.PartVersions!.First().PartUsages!.Count(),
                CustomValues = JsonSerializer.Deserialize<Dictionary<string, string>>(entity.CustomValues)!,
            };
            dto.Populate(entity);
            return dto;
        }
    }
}
