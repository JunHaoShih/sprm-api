using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SprmApi.Core
{
    /// <summary>
    /// 可自定義物件
    /// </summary>
    public abstract class CustomizeObject : SPRMObject
    {
        /// <summary>
        /// 編號
        /// </summary>
        [Required]
        [Column("number", TypeName = "varchar(50)")]
        [MaxLength(50)]
        [Comment("編號")]
        public string Number { get; set; } = null!;

        /// <summary>
        /// 名稱
        /// </summary>
        [Required]
        [Column("name", TypeName = "varchar(50)")]
        [MaxLength(50)]
        [Comment("名稱")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 是否系統預設
        /// </summary>
        [Required]
        [Column("is_system_default")]
        [Comment("是否為系統預設")]
        public bool IsSystemDefault { get; set; }

        /// <summary>
        /// 語系與對應翻譯
        /// </summary>
        [Required]
        [Column("languages", TypeName = "jsonb")]
        [Comment("語系與對應翻譯")]
        public Dictionary<string, string> Languages { get; set; } = new Dictionary<string, string>();
    }
}
