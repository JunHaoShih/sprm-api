using System.Text.Json.Serialization;
using SprmCommon.Enumerations;
using SprmCommon.Validations;

namespace SprmAuthentication.Core.Permissions.Dto
{
    /// <summary>
    /// 變更權限DTO
    /// </summary>
    public class SavePermissionDto
    {
        /// <summary>
        /// 物件類型
        /// </summary>
        [EnumValidation]
        public SprmObjectType ObjectType { get; set; }

        /// <summary>
        /// 允許建立
        /// </summary>
        [JsonRequired]
        public bool CreatePermitted { get; set; }

        /// <summary>
        /// 允許讀取
        /// </summary>
        [JsonRequired]
        public bool ReadPermitted { get; set; }

        /// <summary>
        /// 允許修改
        /// </summary>
        [JsonRequired]
        public bool UpdatePermitted { get; set; }

        /// <summary>
        /// 允許刪除
        /// </summary>
        [JsonRequired]
        public bool DeletePermitted { get; set; }

        /// <summary>
        /// Parse DTO to entity
        /// </summary>
        /// <returns></returns>
        public Permission ToEntity(long userId)
        {
            return new Permission
            {
                ObjectTypeId = (long)ObjectType,
                CreatePermitted = CreatePermitted,
                ReadPermitted = ReadPermitted,
                UpdatePermitted = UpdatePermitted,
                DeletePermitted = DeletePermitted,
                UserId = userId,
            };
        }

        /// <summary>
        /// Apply data to entity
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public Permission ApplyUpdate(Permission permission)
        {
            permission.ObjectTypeId = (long)ObjectType;
            permission.CreatePermitted = CreatePermitted;
            permission.ReadPermitted = ReadPermitted;
            permission.UpdatePermitted = UpdatePermitted;
            permission.DeletePermitted = DeletePermitted;
            return permission;
        }
    }
}
