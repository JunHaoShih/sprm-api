using System.Text.Json.Serialization;

namespace SprmApi.Core.Auth.Dto
{
    /// <summary>
    /// 使用者驗證DTO
    /// </summary>
    public class AuthenticateDto
    {
        /// <summary>
        /// 使用者名稱
        /// </summary>
        [JsonRequired]
        public string Username { get; set; } = null!;

        /// <summary>
        /// 密碼
        /// </summary>
        [JsonRequired]
        public string Password { get; set; } = null!;
    }
}
