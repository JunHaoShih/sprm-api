using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SprmApi.Core.ObjectTypes
{
    /// <summary>
    /// 物件類型
    /// </summary>
    [Table("object_types", Schema = "sprm")]
    [Comment("物件類型")]
    public class ObjectType : SprmObject
    {
        /// <summary>
        /// 物件類型編號
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(200)")]
        [MaxLength(200)]
        [Comment("物件類型編號")]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 物件類型名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        [MaxLength(50)]
        [Comment("物件名稱")]
        public string Name { get; set; } = null!;
    }

    /// <summary>
    /// 物件類別id
    /// </summary>
    public enum SprmObjectType
    {
        /// <summary>
        /// 料件版本
        /// </summary>
        PartVersion = 1,
        /// <summary>
        /// 料件使用關係
        /// </summary>
        PartUsage = 2,
        /// <summary>
        /// 產品途程
        /// </summary>
        Routing = 3,
        /// <summary>
        /// 產品途程版本
        /// </summary>
        RoutingVersion = 4,
        /// <summary>
        /// 製程
        /// </summary>
        Process = 5,
        /// <summary>
        /// 工藝路徑使用關係
        /// </summary>
        RoutingUsage = 6,
    }
}
