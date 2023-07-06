using Microsoft.EntityFrameworkCore;
using SprmApi.Core.MakeTypes;
using SprmApi.Core.Processes;
using SprmApi.Core.Routings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SprmApi.Core.RoutingProcesses
{
    /// <summary>
    /// 途程之製程
    /// </summary>
    [Table("routing_processes", Schema = "sprm")]
    [Comment("途程之製程")]
    public class RoutingProcess : SPRMObject
    {
        /// <summary>
        /// 關聯途程版本id
        /// </summary>
        [Required]
        [Column("routing_version_id")]
        [ForeignKey("RoutingVersion")]
        [Comment("途程版本id")]
        public long RoutingVersionId { get; set; }

        /// <summary>
        /// 關聯途程版本 (需要include)
        /// </summary>
        public RoutingVersion? RoutingVersion { get; set; }

        /// <summary>
        /// 途程內編號
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(50)")]
        [MaxLength(50)]
        [Comment("途程內編號")]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 關聯製程id
        /// </summary>
        [Required]
        [Column("process_id")]
        [ForeignKey("Process")]
        [Comment("製程id")]
        public long ProcessId { get; set; }

        /// <summary>
        /// 關聯製程 (需要include)
        /// </summary>
        public Process? Process { get; set; }

        /// <summary>
        /// 順序
        /// </summary>
        [Required]
        [Column("order")]
        [Comment("製程順序")]
        public int Order { get; set; }

        /// <summary>
        /// 上料工時(毫秒)
        /// </summary>
        [Column("import_time")]
        [Comment("上料工時(毫秒)")]
        public int? ImportTime { get; set; }

        /// <summary>
        /// 下料工時(毫秒)
        /// </summary>
        [Column("export_time")]
        [Comment("下料工時(毫秒)")]
        public int? ExportTime { get; set; }

        /// <summary>
        /// 製造類型id
        /// </summary>
        [Required]
        [Column("make_type_id")]
        [ForeignKey("MakeType")]
        [Comment("製造類型id")]
        public long MakeTypeId { get; set; }

        /// <summary>
        /// 製造類型 (需要include)
        /// </summary>
        public MakeType? MakeType { get; set; }
    }
}
