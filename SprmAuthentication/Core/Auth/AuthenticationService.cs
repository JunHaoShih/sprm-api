using SprmAuthentication.Core.AppUsers;
using SprmAuthentication.Core.Auth.Dto;
using SprmAuthentication.Settings;
using SprmCommon.Authentications;
using SprmCommon.Error;
using SprmCommon.Exceptions;

namespace SprmAuthentication.Core.Auth
{
    /// <summary>
    /// Authentication service
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAppUserService _appUserService;

        private readonly IJwtService _jwtService;

        private readonly ApiSettings _settings;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appUserService"></param>
        /// <param name="jwtService"></param>
        /// <param name="settings"></param>
        public AuthenticationService(IAppUserService appUserService, IJwtService jwtService, ApiSettings settings)
        {
            _appUserService = appUserService;
            _jwtService = jwtService;
            _settings = settings;
        }

        /// <inheritdoc/>
        public async Task<AuthenticateResponseDto> Authenticate(AuthenticateRequestDto authDto)
        {
            AppUser? appUser = await _appUserService.GetByAuthenticateAsync(authDto.Username, authDto.Password);
            if (appUser == null)
            {
                throw new SprmException(ErrorCode.IncorrectUsernameOrPassword, "");
            }
            string token = await _jwtService.GenerateAccessToken(appUser);
            string refreshToken = _jwtService.GenerateRefreshToken(appUser);
            return new()
            {
                Token = token,
                RefreshToken = refreshToken,
            };
        }

        /// <inheritdoc/>
        public ReAuthenticateResponse ReAuthenticate(ReAuthenticateRequest reauthDto)
        {
            JwtAccessPayload payload = JwtBasePayload.DecryptToken<JwtAccessPayload>(reauthDto.AccessToken, _settings.JwtSettings.SignKey);
            string innerToken = _jwtService.GenerateInnerToken(payload);
            return new()
            {
                InnerToken = innerToken,
            };
        }

        /// <inheritdoc/>
        public async Task<AuthenticateResponseDto> Refresh(RefreshTokenDto refreshDto)
        {
            JwtBasePayload payload = JwtBasePayload.DecryptToken<JwtBasePayload>(refreshDto.RefreshToken, _settings.JwtSettings.SignKey);
            AppUser? appUser = await _appUserService.GetByUsernameAsync(payload.Subject);
            if (appUser == null)
            {
                throw new SprmAuthException(ErrorCode.UserNotExist, "");
            }
            string token = await _jwtService.GenerateAccessToken(appUser);
            return new()
            {
                Token = token,
                RefreshToken = refreshDto.RefreshToken,
            };
        }
    }
}
