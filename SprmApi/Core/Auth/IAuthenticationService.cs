using SprmApi.Core.Auth.Dto;

namespace SprmApi.Core.Auth
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
        /// Refresh token
        /// </summary>
        /// <param name="refreshDto"></param>
        /// <returns></returns>
        Task<AuthenticateResponseDto> Refresh(RefreshTokenDto refreshDto);

        /// <summary>
        /// Logout and invalidate refresh token
        /// </summary>
        /// <param name="refreshDto"></param>
        /// <returns></returns>
        Task Logout(RefreshTokenDto refreshDto);
    }
}
