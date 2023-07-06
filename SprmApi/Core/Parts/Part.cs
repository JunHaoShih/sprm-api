using Microsoft.EntityFrameworkCore;
using SprmApi.Core.PartUsages;
using SprmApi.Core.Routings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SprmApi.Core.Parts
{
    /// <summary>
    /// 零件
    /// </summary>
    [Table("parts", Schema = "sprm")]
    [Comment("零件")]
    public class Part : SPRMObject
    {
        /// <summary>
        /// 料號
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(50)")]
        [MaxLength(50)]
        [Comment("料號")]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 料件名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        [MaxLength(50)]
        [Comment("零件名稱")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 視圖類型
        /// </summary>
        [Required]
        [Column("view_type")]
        [Comment("視圖類型")]
        public ViewType ViewType { get; set; }

        /// <summary>
        /// 是否簽出
        /// </summary>
        [Required]
        [Column("checkout")]
        [Comment("是否簽出")]
        public bool Checkout { get; set; }

        /// <summary>
        /// 產品版本清單 (需要include)
        /// </summary>
        public ICollection<PartVersion>? PartVersions { get; set; }

        /// <summary>
        /// 工藝路徑清單 (需要include)
        /// </summary>
        public ICollection<Routing>? Routings { get; set; }

        /// <summary>
        /// 父使用關係清單 (需要include)
        /// </summary>
        public ICollection<PartUsage>? ParentPartUsages { get; set; }
    }

    /// <summary>
    /// 視圖類型
    /// </summary>
    public enum ViewType
    {
        /// <summary>
        /// 設計
        /// </summary>
        Design = 0,
        /// <summary>
        /// 製造
        /// </summary>
        Manufacturing = 1,
    }
}
