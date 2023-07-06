using Microsoft.EntityFrameworkCore;
using SprmApi.Core.Parts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SprmApi.Core.Routings
{
    /// <summary>
    /// 工藝路徑
    /// </summary>
    [Table("routings", Schema = "sprm")]
    [Comment("工藝路徑")]
    public class Routing : SprmObject
    {
        /// <summary>
        /// 關聯料件id
        /// </summary>
        [Required]
        [Column("part_id")]
        [ForeignKey("Part")]
        [Comment("對應料件id")]
        public long PartId { get; set; }

        /// <summary>
        /// 關聯料件 (需要include才可使用)
        /// </summary>
        public Part? Part { get; set; }

        /// <summary>
        /// 工藝路徑名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        [MaxLength(50)]
        [Comment("工藝路徑名稱")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 是否為預設工藝路徑
        /// </summary>
        [Required]
        [Column("is_default")]
        [Comment("是否為預設工藝路徑")]
        public bool IsDefault { get; set; }

        /// <summary>
        /// 是否簽出
        /// </summary>
        [Required]
        [Column("checkout")]
        [Comment("是否簽出")]
        public bool Checkout { get; set; }

        /// <summary>
        /// 工藝路徑版本清單 (需要include)
        /// </summary>
        public ICollection<RoutingVersion>? RoutingVersions { get; set; }
    }
}
