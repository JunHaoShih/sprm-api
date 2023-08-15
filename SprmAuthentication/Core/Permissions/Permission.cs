using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SprmCommon;
using SprmAuthentication.Core.AppUsers;
using SprmCommon.Dto;
using SprmCommon.Enumerations;
using SprmCommon.Exceptions;
using SprmCommon.Error;

namespace SprmAuthentication.Core.Permissions
{
    /// <summary>
    /// 權限
    /// </summary>
    [Table("permissions", Schema = "sprm-auth")]
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
        [Comment("物件類型id")]
        public long ObjectTypeId { get; set; }

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

        /// <summary>
        /// Parse entity to DTO
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public PermissionDto ToDto()
        {
            SprmObjectType entityObjectType = (SprmObjectType)ObjectTypeId;
            if (!Enum.IsDefined<SprmObjectType>(entityObjectType))
            {
                throw new SprmException(ErrorCode.Error, "Object type does not exist");
            }
            PermissionDto dto = new()
            {
                ObjectType = (SprmObjectType)ObjectTypeId,
                CreatePermitted = CreatePermitted,
                ReadPermitted = ReadPermitted,
                UpdatePermitted = UpdatePermitted,
                DeletePermitted = DeletePermitted
            };
            return dto;
        }
    }
}
