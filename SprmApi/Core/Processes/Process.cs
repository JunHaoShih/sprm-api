using Microsoft.EntityFrameworkCore;
using SprmApi.Core.MakeTypes;
using SprmApi.Core.ProcessTypes;
using SprmApi.Core.RoutingUsages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace SprmApi.Core.Processes
{
    /// <summary>
    /// 製程
    /// </summary>
    [Table("processes", Schema = "sprm")]
    [Comment("製程")]
    public class Process : SPRMObject, IDisposable
    {
        /// <summary>
        /// 製程代碼
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(50)")]
        [MaxLength(50)]
        [Comment("製程代碼")]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 製程名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        [MaxLength(50)]
        [Comment("製程名稱")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 製程類型id
        /// </summary>
        [Required]
        [Column("process_type_id")]
        [ForeignKey("ProcessType")]
        [Comment("製程類型id")]
        public long ProcessTypeId { get; set; }

        /// <summary>
        /// 製程類型 (需要include才可使用)
        /// </summary>
        public ProcessType? ProcessType { get; set; }

        /// <summary>
        /// 預設上料工時(毫秒)
        /// </summary>
        [Column("default_import_time")]
        [Comment("預設上料工時(毫秒)")]
        public int DefaultImportTime { get; set; }

        /// <summary>
        /// 預設下料工時(毫秒)
        /// </summary>
        [Column("default_export_time")]
        [Comment("預設下料工時(毫秒)")]
        public int DefaultExportTime { get; set; }

        /// <summary>
        /// 預設製造類型id
        /// </summary>
        [Required]
        [Column("default_make_type_id")]
        [ForeignKey("MakeType")]
        [Comment("預設製造類型id")]
        public long DefaultMakeTypeId { get; set; }

        /// <summary>
        /// 預設製造類型 (需要include才可使用)
        /// </summary>
        public MakeType? MakeType { get; set; }

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        [Required]
        [Column("custom_values")]
        [Comment("自訂屬性值")]
        public JsonDocument CustomValues { get; set; } = null!;

        /// <summary>
        /// 所有相關的工藝路徑使用關係 (需要include才可使用)
        /// </summary>
        public ICollection<RoutingUsage>? RoutingUsages { get; set; }

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
