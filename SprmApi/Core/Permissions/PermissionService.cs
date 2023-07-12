using Microsoft.EntityFrameworkCore;
using SprmApi.Core.Permissions.Dto;

namespace SprmApi.Core.Permissions
{
    /// <summary>
    /// Permission service
    /// </summary>
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionDao _permissionDao;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="permissionDao"></param>
        public PermissionService(IPermissionDao permissionDao)
        {
            _permissionDao = permissionDao;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PermissionDto>> GetByUserIdAsync(long userId)
        {
            IQueryable<Permission> permissionsQuery = _permissionDao.GetByUserId(userId);
            List<Permission> permissions = await permissionsQuery.ToListAsync();
            return permissions.Select(p => PermissionDto.Parse(p));
        }
    }
}
