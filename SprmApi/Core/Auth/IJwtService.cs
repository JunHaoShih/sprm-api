using SprmApi.Core.AppUsers;

namespace SprmApi.Core.Auth
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
        /// Generate refresh token for a user
        /// </summary>
        /// <param name="appUser"></param>
        /// <returns></returns>
        string GenerateRefreshToken(AppUser appUser);

        /// <summary>
        /// Decrypt token and return payload
        /// </summary>
        /// <typeparam name="T">Payload type</typeparam>
        /// <param name="token">Token you want to decrypt</param>
        /// <returns></returns>
        T DecryptToken<T>(string token) where T : JwtBasePayload;
    }
}
