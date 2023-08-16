using SprmApi.Core.ObjectTypes;
using SprmCommon.Error;
using SprmCommon.Exceptions;

namespace SprmApi.Core.Permissions.Dto
{
    /// <summary>
    /// 權限DTO
    /// </summary>
    public class PermissionDto
    {
        /// <summary>
        /// 物件類型
        /// </summary>
        public SprmObjectType ObjectType { get; set; }

        /// <summary>
        /// 允許建立
        /// </summary>
        public bool CreatePermitted { get; set; }

        /// <summary>
        /// 允許讀取
        /// </summary>
        public bool ReadPermitted { get; set; }

        /// <summary>
        /// 允許修改
        /// </summary>
        public bool UpdatePermitted { get; set; }

        /// <summary>
        /// 允許刪除
        /// </summary>
        public bool DeletePermitted { get; set; }

        /// <summary>
        /// Parse entity to DTO
        /// </summary>
        /// <param name="entity">Entity you want to parse</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static PermissionDto Parse(Permission entity)
        {
            SprmObjectType entityObjectType = (SprmObjectType)entity.ObjectTypeId;
            if (!Enum.IsDefined<SprmObjectType>(entityObjectType))
            {
                throw new SprmException(ErrorCode.Error, "Object type does not exist");
            }
            PermissionDto dto = new()
            {
                ObjectType = (SprmObjectType)entity.ObjectTypeId,
                CreatePermitted = entity.CreatePermitted,
                ReadPermitted = entity.ReadPermitted,
                UpdatePermitted = entity.UpdatePermitted,
                DeletePermitted = entity.DeletePermitted
            };
            return dto;
        }
    }
}
