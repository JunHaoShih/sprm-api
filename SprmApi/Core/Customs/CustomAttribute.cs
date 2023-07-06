using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SprmApi.Core.Customs
{
    /// <summary>
    /// 自訂屬性
    /// </summary>
    [Table("custom_attributes", Schema = "sprm")]
    [Comment("自訂屬性")]
    public class CustomAttribute : CustomizeObject
    {
        /// <summary>
        /// 自訂屬性類型
        /// </summary>
        [Required]
        [Column("attribute_type")]
        [Comment("自訂屬性類型")]
        public AttributeType AttributeType { get; set; }

        /// <summary>
        /// 自訂屬性顯示類型
        /// </summary>
        [Required]
        [Column("display_type")]
        [Comment("自訂屬性顯示類型")]
        public DisplayType DisplayType { get; set; }

        /// <summary>
        /// 是否停用
        /// </summary>
        [Required]
        [Column("is_disabled")]
        [Comment("是否停用")]
        public bool IsDisabled { get; set; }

        /// <summary>
        /// 自訂選項
        /// </summary>
        [Required]
        [Column("options", TypeName = "jsonb")]
        [Comment("自訂選項")]
        public IEnumerable<CustomOption> Options { get; set; } = Enumerable.Empty<CustomOption>();
    }

    /// <summary>
    /// 自訂選項
    /// </summary>
    public class CustomOption
    {
        /// <summary>
        /// 選項key
        /// </summary>
        public string Key { get; set; } = null!;

        /// <summary>
        /// 選項value
        /// </summary>
        public string Value { get; set; } = null!;

        /// <summary>
        /// 語系與對應翻譯
        /// </summary>
        public Dictionary<string, string> Languages { get; set; } = new Dictionary<string, string>();
    }

    /// <summary>
    /// 自訂屬性類型
    /// </summary>
    public enum AttributeType
    {
        /// <summary>
        /// 字串
        /// </summary>
        String = 0,
    }

    /// <summary>
    /// 顯示類型
    /// </summary>
    public enum DisplayType
    {
        /// <summary>
        /// 顯示值
        /// </summary>
        Value = 0,

        /// <summary>
        /// 單選
        /// </summary>
        SingleSelect = 1,
    }
}
