using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
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
        /// 未知(表示錯誤)
        /// </summary>
        [Description("未知(表示錯誤)")]
        Unknown = 0,
        /// <summary>
        /// 料件版本
        /// </summary>
        [Description("料件版本")]
        PartVersion = 1,
        /// <summary>
        /// 料件使用關係
        /// </summary>
        [Description("料件使用關係")]
        PartUsage = 2,
        /// <summary>
        /// 工藝路徑
        /// </summary>
        [Description("工藝路徑")]
        Routing = 3,
        /// <summary>
        /// 工藝路徑版本
        /// </summary>
        [Description("工藝路徑版本")]
        RoutingVersion = 4,
        /// <summary>
        /// 製程
        /// </summary>
        [Description("製程")]
        Process = 5,
        /// <summary>
        /// 工藝路徑使用關係
        /// </summary>
        [Description("工藝路徑使用關係")]
        RoutingUsage = 6,
        /// <summary>
        /// 自訂屬性
        /// </summary>
        [Description("自訂屬性")]
        CustomAttribute = 7,
        /// <summary>
        /// 屬性連結
        /// </summary>
        [Description("屬性連結")]
        AttributeLink = 8,
        /// <summary>
        /// App使用者
        /// </summary>
        [Description("App使用者")]
        AppUser = 9,
    }
}
