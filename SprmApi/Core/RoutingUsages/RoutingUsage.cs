using Microsoft.EntityFrameworkCore;
using SprmApi.Core.Processes;
using SprmApi.Core.Routings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace SprmApi.Core.RoutingUsages
{
    /// <summary>
    /// 工藝路徑使用關係
    /// </summary>
    [Table("routing_usages", Schema = "sprm")]
    [Comment("工藝路徑使用關係")]
    public class RoutingUsage : SPRMObject, IDisposable
    {
        /// <summary>
        /// 該使用關係所屬工藝路徑版本的id
        /// </summary>
        [Required]
        [Column("root_version_id")]
        [ForeignKey("RootVersion")]
        [Comment("該使用關係所屬工藝路徑版本的id")]
        public long RootVersionId { get; set; }

        /// <summary>
        /// 該使用關係所屬工藝路徑版本 (需要include)
        /// </summary>
        public RoutingVersion? RootVersion { get; set; }

        /// <summary>
        /// 該使用關係所屬的父使用關係id
        /// </summary>
        [Column("parent_usage_id")]
        [ForeignKey("ParentUsage")]
        [Comment("該使用關係所屬的父使用關係id")]
        public long? ParentUsageId { get; set; }

        /// <summary>
        /// 父向使用關係 (需要include)
        /// </summary>
        public RoutingUsage? ParentUsage { get; set; }

        /// <summary>
        /// 使用關係編號
        /// </summary>
        [Required]
        [Column("number")]
        [Comment("使用關係編號")]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 製程id
        /// </summary>
        [Column("process_id")]
        [ForeignKey("Process")]
        [Comment("製程id")]
        public long ProcessId { get; set; }

        /// <summary>
        /// 製程，需include
        /// </summary>
        public Process? Process { get; set; }

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        [Required]
        [Column("custom_values")]
        [Comment("自訂屬性值")]
        public JsonDocument CustomValues { get; set; } = null!;

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
