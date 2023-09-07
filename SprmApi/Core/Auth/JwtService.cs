using Jose;
using SprmApi.Core.AppUsers;
using SprmApi.Core.Permissions;
using SprmApi.Core.Permissions.Dto;
using SprmApi.Core.Redis;
using SprmCommon.Error;
using SprmCommon.Exceptions;
using SprmCommon.Extensions;
using StackExchange.Redis;
using System.Text;
using System.Text.Json;

namespace SprmApi.Core.Auth
{
    /// <summary>
    /// 專門處理JWT的服務
    /// </summary>
    public class JwtService : IJwtService
    {
        private const int RefreshTokenExpireTime = 86400;

        private const int AccessTokenExpireTime = 1800;

        private readonly Settings.JwtSettings _settings;

        private readonly IPermissionService _permissionService;

        private readonly IRedisService _redisService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="permissionService"></param>
        /// <param name="redisService"></param>
        public JwtService(
            Settings.JwtSettings settings,
            IPermissionService permissionService,
            IRedisService redisService
        )
        {
            _settings = settings;
            _permissionService = permissionService;
            _redisService = redisService;
        }

        /// <inheritdoc/>
        public async Task<string> GenerateAccessToken(AppUser appUser)
        {
            DateTime iat = DateTime.Now;
            DateTime exp = iat.AddSeconds(AccessTokenExpireTime);
            IEnumerable<PermissionDto> permissions = await _permissionService.GetByUserIdAsync(appUser.Id);
            var payload = new JwtAccessPayload
            {
                Subject = appUser.Username,
                Issuer = _settings.Issuer,
                IssuedAt = iat.GetUnixTimestamp(),
                Expiration = exp.GetUnixTimestamp(),
                IsAdmin = appUser.IsAdmin,
                Permissions = permissions,
            };
            string json = JsonSerializer.Serialize(payload);
            string jwtToken = JWT.Encode(json, Encoding.UTF8.GetBytes(_settings.SignKey), JwsAlgorithm.HS256);
            return jwtToken;
        }

        /// <inheritdoc/>
        public string GenerateRefreshToken(AppUser appUser)
        {
            DateTime iat = DateTime.Now;
            DateTime exp = iat.AddSeconds(RefreshTokenExpireTime);
            JwtBasePayload payload = new()
            {
                Subject = appUser.Username,
                Issuer = _settings.Issuer,
                IssuedAt = iat.GetUnixTimestamp(),
                Expiration = exp.GetUnixTimestamp(),
            };
            string json = JsonSerializer.Serialize(payload);
            string jwtToken = JWT.Encode(json, Encoding.UTF8.GetBytes(_settings.SignKey), JwsAlgorithm.HS256);
            AddRefreshWhiteList(appUser.Username, jwtToken);
            return jwtToken;
        }

        private string GetRefreshTokenKey(string username, string refreshToken)
        {
            return $"{username}@@refreshTokens@@{refreshToken}";
        }

        private void AddRefreshWhiteList(string username, string refreshToken)
        {
            IDatabase db = _redisService.GetDatabase();
            string key = GetRefreshTokenKey(username, refreshToken);
            db.StringSet(key, refreshToken);
            db.KeyExpire(key, TimeSpan.FromSeconds(RefreshTokenExpireTime));
        }

        /// <inheritdoc/>
        public T DecryptToken<T>(string token) where T : JwtBasePayload
        {
            string json = JWT.Decode(token, Encoding.UTF8.GetBytes(_settings.SignKey), JwsAlgorithm.HS256);
            T? payload = JsonSerializer.Deserialize<T>(json);
            if (payload == null)
            {
                throw new SprmAuthException(ErrorCode.InvalidToken, "Token is null");
            }
            long nowUnixTimestamp = DateTime.Now.GetUnixTimestamp();
            if (payload.Expiration < nowUnixTimestamp)
            {
                throw new SprmAuthException(ErrorCode.InvalidToken, "Token expired!");
            }
            return payload;
        }

        /// <inheritdoc/>
        public void RemoveRefreshToken(AppUser appUser, string refreshToken)
        {
            IDatabase db = _redisService.GetDatabase();
            string key = GetRefreshTokenKey(appUser.Username, refreshToken);
            db.KeyDelete(key);
        }

        /// <inheritdoc/>
        public bool IsRefreshTokenWhiteList(AppUser appUser, string refreshToken)
        {
            IDatabase db = _redisService.GetDatabase();
            string key = GetRefreshTokenKey(appUser.Username, refreshToken);
            return db.KeyExists(key);
        }
    }
}
