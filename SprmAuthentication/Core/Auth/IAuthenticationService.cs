using SprmAuthentication.Core.Auth.Dto;

namespace SprmAuthentication.Core.Auth
{
    /// <summary>
    /// Authentication service interface
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Authenticate by username and password
        /// </summary>
        /// <param name="authDto"></param>
        /// <returns></returns>
        Task<AuthenticateResponseDto> Authenticate(AuthenticateRequestDto authDto);

        /// <summary>
        /// Reauthenticate token to inner token
        /// </summary>
        /// <param name="reauthDto"></param>
        /// <returns></returns>
        ReAuthenticateResponse ReAuthenticate(ReAuthenticateRequest reauthDto);

        /// <summary>
        /// Refresh token
        /// </summary>
        /// <param name="refreshDto"></param>
        /// <returns></returns>
        Task<AuthenticateResponseDto> Refresh(RefreshTokenDto refreshDto);
    }
}
