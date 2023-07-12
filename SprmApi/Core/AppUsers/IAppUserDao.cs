using SprmApi.Core.AppUsers.Dto;

namespace SprmApi.Core.AppUsers
{
    /// <summary>
    /// AppUser DAO interface
    /// </summary>
    public interface IAppUserDao
    {
        /// <summary>
        /// 用帳號和hash密碼取使用者
        /// </summary>
        /// <param name="username">使用者名稱</param>
        /// <param name="passwordHash">密碼hash</param>
        /// <returns></returns>
        Task<AppUser?> GetByAuthenticateAsync(string username, string passwordHash);

        /// <summary>
        /// Insert a AppUser
        /// </summary>
        /// <param name="newAppUser"></param>
        /// <param name="creator"></param>
        /// <returns></returns>
        Task<AppUser> InsertAsync(CreateAppUserDto newAppUser, AppUser creator);

        /// <summary>
        /// Get AppUser by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<AppUser?> GetByUsernameAsync(string username);

        /// <summary>
        /// Create default admin(Please only use this on create default admin)
        /// </summary>
        /// <param name="newAppUser"></param>
        /// <returns></returns>
        Task<AppUser> InsertDefaultAsync(CreateAppUserDto newAppUser);

        /// <summary>
        /// Get app user by user id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        Task<AppUser?> GetAsync(long id);
    }
}
