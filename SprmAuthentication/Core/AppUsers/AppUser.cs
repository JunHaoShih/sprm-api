using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using SprmCommon;

namespace SprmAuthentication.Core.AppUsers
{
    /// <summary>
    /// App使用者
    /// </summary>
    [Table("app_users", Schema = "sprm")]
    [Comment("App使用者")]
    public class AppUser : SprmObject, IDisposable
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
        [Column("password", TypeName = "text")]
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

        /// <summary>
        /// 是否為系統管理員
        /// </summary>
        [Required]
        [Column("is_admin")]
        [Comment("是否為系統管理員")]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 自訂屬性值
        /// </summary>
        [Required]
        [Column("custom_values")]
        [Comment("自訂屬性值")]
        public JsonDocument CustomValues { get; set; } = null!;

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose custom values
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            CustomValues.Dispose();
        }
    }
}
