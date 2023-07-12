using Microsoft.EntityFrameworkCore;
using SprmApi.Core.AppUsers;
using SprmApi.Core.ObjectTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SprmApi.Core.Permissions
{
    /// <summary>
    /// 權限
    /// </summary>
    [Table("permissions", Schema = "sprm")]
    [Comment("權限")]
    public class Permission : SprmObject
    {
        /// <summary>
        /// App使用者id
        /// </summary>
        [Required]
        [Column("user_id")]
        [ForeignKey("User")]
        [Comment("App使用者id")]
        public long UserId { get; set; }

        /// <summary>
        /// App使用者 (需要include才可使用)
        /// </summary>
        public AppUser? User { get; set; }

        /// <summary>
        /// 物件類型
        /// </summary>
        [Required]
        [Column("object_type_id")]
        [ForeignKey("ObjectType")]
        [Comment("物件類型id")]
        public long ObjectTypeId { get; set; }

        /// <summary>
        /// 物件類型 (需要include才可使用)
        /// </summary>
        public ObjectType? ObjectType { get; set; }

        /// <summary>
        /// 允許建立
        /// </summary>
        [Required]
        [Column("create_permitted")]
        [Comment("允許建立")]
        public bool CreatePermitted { get; set; }

        /// <summary>
        /// 允許讀取
        /// </summary>
        [Required]
        [Column("read_permitted")]
        [Comment("允許讀取")]
        public bool ReadPermitted { get; set; }

        /// <summary>
        /// 允許修改
        /// </summary>
        [Required]
        [Column("update_permitted")]
        [Comment("允許修改")]
        public bool UpdatePermitted { get; set; }

        /// <summary>
        /// 允許刪除
        /// </summary>
        [Required]
        [Column("delete_permitted")]
        [Comment("允許刪除")]
        public bool DeletePermitted { get; set; }
    }
}
