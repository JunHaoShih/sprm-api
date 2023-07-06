using Microsoft.EntityFrameworkCore;
using SprmApi.Core.PartUsages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace SprmApi.Core.Parts
{
    /// <summary>
    /// 零件版本
    /// </summary>
    [Table("part_versions", Schema = "sprm")]
    [Comment("零件")]
    public class PartVersion : IterableObject<Part>, IDisposable
    {
        /// <summary>
        /// 自訂屬性值
        /// </summary>
        [Required]
        [Column("custom_values")]
        [Comment("自訂屬性值")]
        public JsonDocument CustomValues { get; set; } = null!;

        /// <summary>
        /// 料件使用關係，需include
        /// </summary>
        public ICollection<PartUsage>? PartUsages { get; set; }

        /// <inheritdoc/>
        public void Dispose()
        {
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
