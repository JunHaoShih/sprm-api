using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SprmApi.Core
{
    /// <summary>
    /// Database基底物件
    /// </summary>
    public abstract class SprmObject
    {
        /// <summary>
        /// System id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", Order = 0)]
        [Comment("system id")]
        public long Id { get; set; }

        /// <summary>
        /// Creator
        /// </summary>
        [Required]
        [Column("create_user", TypeName = "varchar(50)", Order = 1)]
        [Comment("Creator")]
        public string CreateUser { get; set; } = "system";

        /// <summary>
        /// Create date
        /// </summary>
        [Required]
        [Column("create_date", Order = 2)]
        [Comment("Create date")]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Updater
        /// </summary>
        [Required]
        [Column("update_user", TypeName = "varchar(50)", Order = 3)]
        [Comment("Updator")]
        public string UpdateUser { get; set; } = "system";

        /// <summary>
        /// Update date
        /// </summary>
        [Required]
        [Column("update_date", Order = 4)]
        [Comment("Update date")]
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Remarks
        /// </summary>
        [Column("remarks", TypeName = "text", Order = 5)]
        [Comment("Remarks")]
        public string? Remarks { get; set; }
    }
}
