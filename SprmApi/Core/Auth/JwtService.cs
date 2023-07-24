using Jose;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Common.Extensions;
using SprmApi.Core.AppUsers;
using SprmApi.Core.Permissions;
using SprmApi.Core.Permissions.Dto;
using SprmApi.Settings;
using System.Text;
using System.Text.Json;

namespace SprmApi.Core.Auth
{
    /// <summary>
    /// 專門處理JWT的服務
    /// </summary>
    public class JwtService : IJwtService
    {
        private readonly ApiSettings _apiSettings;

        private readonly IPermissionService _permissionService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiSettings"></param>
        /// <param name="permissionService"></param>
        public JwtService(ApiSettings apiSettings, IPermissionService permissionService)
        {
            _apiSettings = apiSettings;
            _permissionService = permissionService;
        }

        /// <inheritdoc/>
        public async Task<string> GenerateAccessToken(AppUser appUser)
        {
            DateTime iat = DateTime.Now;
            DateTime exp = iat.AddMinutes(30);
            IEnumerable<PermissionDto> permissions = await _permissionService.GetByUserIdAsync(appUser.Id);
            var payload = new JwtAccessPayload
            {
                Subject = appUser.Username,
                Issuer = _apiSettings.JwtSettings.Issuer,
                IssuedAt = iat.GetUnixTimestamp(),
                Expiration = exp.GetUnixTimestamp(),
                IsAdmin = appUser.IsAdmin,
                Permissions = permissions,
            };
            string json = JsonSerializer.Serialize(payload);
            string jwtToken = JWT.Encode(json, Encoding.UTF8.GetBytes(_apiSettings.JwtSettings.SignKey), JwsAlgorithm.HS256);
            return jwtToken;
        }

        /// <inheritdoc/>
        public string GenerateRefreshToken(AppUser appUser)
        {
            DateTime iat = DateTime.Now;
            DateTime exp = iat.AddDays(1);
            JwtBasePayload payload = new()
            {
                Subject = appUser.Username,
                Issuer = _apiSettings.JwtSettings.Issuer,
                IssuedAt = iat.GetUnixTimestamp(),
                Expiration = exp.GetUnixTimestamp(),
            };
            string json = JsonSerializer.Serialize(payload);
            string jwtToken = JWT.Encode(json, Encoding.UTF8.GetBytes(_apiSettings.JwtSettings.SignKey), JwsAlgorithm.HS256);
            return jwtToken;
        }

        /// <inheritdoc/>
        public T DecryptToken<T>(string token) where T: JwtBasePayload
        {
            string json = JWT.Decode(token, Encoding.UTF8.GetBytes(_apiSettings.JwtSettings.SignKey), JwsAlgorithm.HS256);
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
