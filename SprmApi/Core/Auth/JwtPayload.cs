using System.Text.Json.Serialization;
using SprmApi.Core.Permissions.Dto;

namespace SprmApi.Core.Auth
{
    /// <summary>
    /// JWT Payload物件
    /// </summary>
    public class JwtPayload
    {
        /// <summary>
        /// JWT用戶
        /// </summary>
        [JsonPropertyName("sub")]
        public string Subject { get; set; } = null!;

        /// <summary>
        /// JWT簽發者
        /// </summary>
        [JsonPropertyName("iss")]
        public string Issuer { get; set; } = null!;

        /// <summary>
        /// JWT簽發時間
        /// </summary>
        [JsonPropertyName("iat")]
        public long IssuedAt { get; set; }

        /// <summary>
        /// JWT過期時間
        /// </summary>
        [JsonPropertyName("exp")]
        public long Expiration { get; set; }

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
