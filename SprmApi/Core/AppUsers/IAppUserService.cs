using SprmApi.Common.Paginations;
using SprmApi.Core.AppUsers.Dto;

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
        Task<AppUser> CreateAppUserAsync(CreateAppUserDto createAppUserDTO);

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
        /// <param name="username">Username</param>
        /// <returns></returns>
        Task<AppUser?> GetByUsernameAsync(string username);

        /// <summary>
        /// Get AppUser by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        Task<AppUser?> GetByIdAsync(long id);

        /// <summary>
        /// Create default admin
        /// </summary>
        /// <returns></returns>
        Task<bool> CreateDefaultAdminAsync();

        /// <summary>
        /// Get by pattern
        /// </summary>
        /// <param name="pattern">Search pattern</param>
        /// <param name="input">Offset pagination input</param>
        /// <returns></returns>
        OffsetPagination<AppUserDto> GetByPattern(string? pattern, OffsetPaginationInput input);
    }
}
