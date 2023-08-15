using SprmAuthentication.Core.Permissions.Dto;

namespace SprmAuthentication.Core.Permissions
{
    /// <summary>
    /// Permission service interface
    /// </summary>
    public interface IPermissionService
    {
        /// <summary>
        /// Get permissions by user id asynchronously
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns></returns>
        Task<IEnumerable<Permission>> GetByUserIdAsync(long userId);

        /// <summary>
        /// Get permissions by username asynchronously
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns></returns>
        Task<IEnumerable<Permission>> GetByUserNameAsync(string username);

        /// <summary>
        /// Save user permissions
        /// </summary>
        /// <param name="permissionDtos">Permission datas</param>
        /// <param name="userId">User id</param>
        /// <param name="requestUser">Request user</param>
        /// <returns></returns>
        Task SaveAsync(IEnumerable<SavePermissionDto> permissionDtos, long userId, string requestUser);
    }
}
