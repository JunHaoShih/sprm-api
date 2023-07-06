using Microsoft.EntityFrameworkCore;
using SprmApi.Core.ObjectTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SprmApi.Core.Customs
{
    /// <summary>
    /// 屬性連結
    /// </summary>
    [Table("attribute_links", Schema = "sprm")]
    [Comment("類型屬性")]
    public class AttributeLink : SprmObject
    {
        /// <summary>
        /// 物件類型id
        /// </summary>
        [Required]
        [Column("object_type_id")]
        [ForeignKey("ObjectType")]
        [Comment("物件類型id")]
        public long ObjectTypeId { get; set; }

        /// <summary>
        /// 物件類型 (需要include)
        /// </summary>
        public ObjectType? ObjectType { get; set; }

        /// <summary>
        /// 自訂屬性id
        /// </summary>
        [Required]
        [Column("attribute_id")]
        [ForeignKey("Attribute")]
        [Comment("自訂屬性id")]
        public long AttributeId { get; set; }

        /// <summary>
        /// 自訂屬性 (需要include)
        /// </summary>
        public CustomAttribute? Attribute { get; set; }
    }
}
