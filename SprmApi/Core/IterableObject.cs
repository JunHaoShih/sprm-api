using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SprmApi.Core
{
    /// <summary>
    /// 可迭代物件
    /// </summary>
    /// <typeparam name="T">可迭代的類別</typeparam>
    public abstract class IterableObject<T> : SprmObject
    {
        /// <summary>
        /// Master id
        /// </summary>
        [Required]
        [Column("master_id")]
        [ForeignKey("Master")]
        [Comment("master id")]
        public long MasterId { get; set; }

        /// <summary>
        /// Master物件 (需要include才可使用)
        /// </summary>
        public T? Master { get; set; }

        /// <summary>
        /// 版本號
        /// </summary>
        [Required]
        [Column("version")]
        [Comment("版本號")]
        public int Version { get; set; }

        /// <summary>
        /// 是否為最新版
        /// </summary>
        [Required]
        [Column("is_latest")]
        [Comment("是否為最新版")]
        public bool IsLatest { get; set; }

        /// <summary>
        /// 是否為草稿
        /// </summary>
        [Required]
        [Column("is_draft")]
        [Comment("是否為草稿")]
        public bool IsDraft { get; set; }
    }
}
