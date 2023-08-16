using SprmCommon.Error;
using SprmCommon.Exceptions;
using SprmApi.Core.AppUsers;
using SprmApi.Core.Auth.Dto;

namespace SprmApi.Core.Auth
{
    /// <summary>
    /// Authentication service
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAppUserService _appUserService;

        private readonly IJwtService _jwtService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appUserService"></param>
        /// <param name="jwtService"></param>
        public AuthenticationService(IAppUserService appUserService, IJwtService jwtService)
        {
            _appUserService = appUserService;
            _jwtService = jwtService;
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
        public async Task<AuthenticateResponseDto> Refresh(RefreshTokenDto refreshDto)
        {
            JwtBasePayload payload = _jwtService.DecryptToken<JwtBasePayload>(refreshDto.RefreshToken);
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
