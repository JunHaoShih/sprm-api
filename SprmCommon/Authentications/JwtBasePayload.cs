using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Jose;
using SprmCommon.Error;
using SprmCommon.Exceptions;
using SprmCommon.Extensions;

namespace SprmCommon.Authentications
{
    /// <summary>
    /// JWT base token payload
    /// </summary>
    public class JwtBasePayload
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

        public static T DecryptToken<T>(string token, string jwtSignKey) where T : JwtBasePayload
        {
            string json = JWT.Decode(token, Encoding.UTF8.GetBytes(jwtSignKey), JwsAlgorithm.HS256);
            T? payload = JsonSerializer.Deserialize<T>(json);
            if (payload == null)
            {
                throw new InvalidOperationException("Token is null");
            }
            long nowUnixTimestamp = DateTime.Now.GetUnixTimestamp();
            if (payload.Expiration < nowUnixTimestamp)
            {
                throw new SprmAuthException(ErrorCode.InvalidToken, "Token expired!");
            }
            return payload;
        }
    }
}
