using SprmApi.Core.Permissions.Dto;

namespace SprmApi.Core.Permissions
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
        Task<IEnumerable<PermissionDto>> GetByUserIdAsync(long userId);

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
