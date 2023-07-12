using Jose;
using Newtonsoft.Json;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Common.Extensions;
using SprmApi.Core.AppUsers;
using SprmApi.Settings;
using System.Text;

namespace SprmApi.Core.Auth
{
    /// <summary>
    /// 專門處理JWT的服務
    /// </summary>
    public class JwtService
    {
        private readonly ApiSettings _apiSettings;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiSettings"></param>
        public JwtService(ApiSettings apiSettings) => _apiSettings = apiSettings;

        /// <summary>
        /// Generate JWT for a user
        /// </summary>
        /// <param name="appUser"></param>
        /// <returns></returns>
        public string GenerateToken(AppUser appUser)
        {
            DateTime iat = DateTime.Now;
            DateTime exp = iat.AddHours(4);
            var payload = new JwtPayload
            {
                Subject = appUser.Username,
                Issuer = _apiSettings.JwtSettings.Issuer,
                IssuedAt = iat.GetUnixTimestamp(),
                Expiration = exp.GetUnixTimestamp(),
                IsAdmin = appUser.IsAdmin,
            };
            string json = JsonConvert.SerializeObject(payload);
            string jwtToken = JWT.Encode(json, Encoding.UTF8.GetBytes(_apiSettings.JwtSettings.SignKey), JwsAlgorithm.HS256);
            return jwtToken;
        }

        /// <summary>
        /// Decrypt token and return payload
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public JwtPayload DecryptToken(string token)
        {
            string json = JWT.Decode(token, Encoding.UTF8.GetBytes(_apiSettings.JwtSettings.SignKey), JwsAlgorithm.HS256);
            JwtPayload? payload = JsonConvert.DeserializeObject<JwtPayload>(json);
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
