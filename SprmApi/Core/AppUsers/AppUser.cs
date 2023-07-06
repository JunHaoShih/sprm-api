using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SprmApi.Core.AppUsers
{
    /// <summary>
    /// App使用者
    /// </summary>
    [Table("app_users", Schema = "sprm")]
    [Comment("App使用者")]
    public class AppUser : SprmObject
    {
        /// <summary>
        /// App使用者名稱
        /// </summary>
        [Required]
        [Column("username", TypeName = "varchar(30)")]
        [MaxLength(30)]
        [Comment("App使用者名稱")]
        public string Username { get; set; } = null!;

        /// <summary>
        /// Password hash
        /// </summary>
        [Required]
        [Column("password", TypeName = "varchar(50)")]
        [MaxLength(100)]
        [Comment("Password hash")]
        public string Password { get; set; } = null!;

        /// <summary>
        /// App使用者姓名
        /// </summary>
        [Required]
        [Column("full_name", TypeName = "varchar(50)")]
        [MaxLength(50)]
        [Comment("App使用者姓名")]
        public string FullName { get; set; } = null!;
    }
}
