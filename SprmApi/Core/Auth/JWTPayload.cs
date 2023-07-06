using Newtonsoft.Json;

namespace SprmApi.Core.Auth
{
    /// <summary>
    /// JWT Payload物件
    /// </summary>
    public class JWTPayload
    {
        /// <summary>
        /// JWT用戶
        /// </summary>
        [JsonProperty("sub")]
        public string Subject { get; set; } = null!;

        /// <summary>
        /// JWT簽發者
        /// </summary>
        [JsonProperty("iss")]
        public string Issuer { get; set; } = null!;

        /// <summary>
        /// JWT簽發時間
        /// </summary>
        [JsonProperty("iat")]
        public long IssuedAt { get; set; }

        /// <summary>
        /// JWT過期時間
        /// </summary>
        [JsonProperty("exp")]
        public long Expiration { get; set; }
    }
}
