using Jose;
using SprmAuthentication.Core.AppUsers;
using SprmAuthentication.Core.Permissions;
using SprmAuthentication.Settings;
using SprmCommon.Authentications;
using SprmCommon.Extensions;
using System.Text;
using System.Text.Json;

namespace SprmAuthentication.Core.Auth
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
            IEnumerable<Permission> permissions = await _permissionService.GetByUserIdAsync(appUser.Id);
            var payload = new JwtAccessPayload
            {
                Subject = appUser.Username,
                Issuer = _apiSettings.JwtSettings.Issuer,
                IssuedAt = iat.GetUnixTimestamp(),
                Expiration = exp.GetUnixTimestamp(),
                IsAdmin = appUser.IsAdmin,
                Permissions = permissions.Select(p => p.ToDto()),
            };
            string json = JsonSerializer.Serialize(payload);
            string jwtToken = JWT.Encode(json, Encoding.UTF8.GetBytes(_apiSettings.JwtSettings.SignKey), JwsAlgorithm.HS256);
            return jwtToken;
        }

        /// <inheritdoc/>
        public string GenerateInnerToken(JwtAccessPayload payload)
        {
            string json = JsonSerializer.Serialize(payload);
            string jwtToken = JWT.Encode(json, Encoding.UTF8.GetBytes(_apiSettings.JwtSettings.InnerSignKey), JwsAlgorithm.HS256);
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
    }
}
