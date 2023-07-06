using SprmApi.Core.AppUsers;
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
        /// <param name="authenticateDTO"></param>
        /// <returns></returns>
        Task<AppUser> Authenticate(AuthenticateDto authenticateDTO);
    }
}
