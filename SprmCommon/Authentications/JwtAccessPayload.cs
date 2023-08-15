using SprmCommon.Dto;
using System;
using System.Linq;

namespace SprmCommon.Authentications
{
    /// <summary>
    /// JWT access token Payload物件
    /// </summary>
    public class JwtAccessPayload : JwtBasePayload
    {
        /// <summary>
        /// 是否為管理員
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 權限
        /// </summary>
        public IEnumerable<PermissionDto> Permissions { get; set; } = new List<PermissionDto>();
    }
}
