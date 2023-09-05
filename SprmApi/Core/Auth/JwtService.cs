﻿using Jose;
using SprmApi.Core.AppUsers;
using SprmApi.Core.Permissions;
using SprmApi.Core.Permissions.Dto;
using SprmApi.Settings;
using SprmCommon.Error;
using SprmCommon.Exceptions;
using SprmCommon.Extensions;
using System.Text;
using System.Text.Json;

namespace SprmApi.Core.Auth
{
    /// <summary>
    /// 專門處理JWT的服務
    /// </summary>
    public class JwtService : IJwtService
    {
        private readonly Settings.JwtSettings _settings;

        private readonly IPermissionService _permissionService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="permissionService"></param>
        public JwtService(Settings.JwtSettings settings, IPermissionService permissionService)
        {
            _settings = settings;
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
            DateTime exp = iat.AddDays(1);
            JwtBasePayload payload = new()
            {
                Subject = appUser.Username,
                Issuer = _settings.Issuer,
                IssuedAt = iat.GetUnixTimestamp(),
                Expiration = exp.GetUnixTimestamp(),
            };
            string json = JsonSerializer.Serialize(payload);
            string jwtToken = JWT.Encode(json, Encoding.UTF8.GetBytes(_settings.SignKey), JwsAlgorithm.HS256);
            return jwtToken;
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
    }
}
