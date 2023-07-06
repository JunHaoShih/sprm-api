using Microsoft.EntityFrameworkCore;
using SprmApi.Core.Parts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace SprmApi.Core.PartUsages
{
    /// <summary>
    /// 零件使用關係
    /// </summary>
    [Table("part_usages", Schema = "sprm")]
    [Comment("零件使用關係")]
    public class PartUsage : SPRMObject, IDisposable
    {
        /// <summary>
        /// 父零件id
        /// </summary>
        [Required]
        [Column("parent_id")]
        [ForeignKey("Parent")]
        [Comment("父零件版本id")]
        public long ParentId { get; set; }

        /// <summary>
        /// 父零件版本 (需要include)
        /// </summary>
        public PartVersion? Parent { get; set; }

        /// <summary>
        /// 子零件id
        /// </summary>
        [Required]
        [Column("child_id")]
        [ForeignKey("Child")]
        [Comment("子零件id")]
        public long ChildId { get; set; }

        /// <summary>
        /// 使用數量
        /// </summary>
        [Required]
        [Column("quantity")]
        [Comment("使用數量")]
        public int Quantity { get; set; }

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        [Required]
        [Column("custom_values")]
        [Comment("自訂屬性值")]
        public JsonDocument CustomValues { get; set; } = null!;

        /// <summary>
        /// 子零件 (需要include)
        /// </summary>
        public Part? Child { get; set; }

        /// <inheritdoc/>
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose custom values
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            CustomValues.Dispose();
        }
    }
}
