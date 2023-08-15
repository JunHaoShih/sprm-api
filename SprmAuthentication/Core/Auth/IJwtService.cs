using SprmAuthentication.Core.AppUsers;
using SprmCommon.Authentications;

namespace SprmAuthentication.Core.Auth
{
    /// <summary>
    /// JWT service interface
    /// </summary>
    public interface IJwtService
    {
        /// <summary>
        /// Generate JWT for a user
        /// </summary>
        /// <param name="appUser"></param>
        /// <returns></returns>
        Task<string> GenerateAccessToken(AppUser appUser);

        /// <summary>
        /// Generate inner token
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        string GenerateInnerToken(JwtAccessPayload payload);

        /// <summary>
        /// Generate refresh token for a user
        /// </summary>
        /// <param name="appUser"></param>
        /// <returns></returns>
        string GenerateRefreshToken(AppUser appUser);
    }
}
