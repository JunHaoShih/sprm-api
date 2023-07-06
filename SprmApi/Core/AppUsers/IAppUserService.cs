using SprmApi.Core.AppUsers.DTOs;

namespace SprmApi.Core.AppUsers
{
    /// <summary>
    /// AppUser service interface
    /// </summary>
    public interface IAppUserService
    {
        /// <summary>
        /// 建立AppUser
        /// </summary>
        /// <param name="createAppUserDTO"></param>
        /// <returns></returns>
        Task<AppUser> CreateAppUserAsync(CreateAppUserDTO createAppUserDTO);

        /// <summary>
        /// 用帳號和hash密碼取使用者
        /// </summary>
        /// <param name="username">使用者名稱</param>
        /// <param name="password">密碼(未加密)</param>
        /// <returns></returns>
        Task<AppUser?> GetByAuthenticateAsync(string username, string password);

        /// <summary>
        /// Get AppUser by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<AppUser?> GetByUsernameAsync(string username);

        /// <summary>
        /// Create default admin
        /// </summary>
        /// <returns></returns>
        Task<bool> CreateDefaultAdminAsync();
    }
}
