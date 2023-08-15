using SprmAuthentication.EFs;
using SprmCommon.Error;
using SprmCommon.Exceptions;

namespace SprmAuthentication.Core.Permissions
{
    /// <summary>
    /// User permission DAO
    /// </summary>
    public class PermissionDao : IPermissionDao
    {
        private readonly AuthenticationContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public PermissionDao(AuthenticationContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IQueryable<Permission> GetByUserId(long userId)
        {
            return _context.Permissions
                .Where(x => x.UserId == userId)
                .AsQueryable();
        }

        /// <inheritdoc/>
        public async Task<Permission> InsertAsync(Permission permission, string creator)
        {
            Permission? duplicatePermission = _context.Permissions
                .SingleOrDefault(p => p.UserId == permission.UserId && p.ObjectTypeId == permission.ObjectTypeId);
            if (duplicatePermission != null)
            {
                throw new SprmException(ErrorCode.DbInsertDuplicate, $"User id: {permission.Id} already has permission of {permission.ObjectTypeId}");
            }
            permission.CreateUser = creator;
            permission.UpdateUser = creator;
            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();
            return permission;
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(Permission permission, string updater)
        {
            permission.UpdateDate = DateTime.UtcNow;
            permission.UpdateUser = updater;
            await _context.SaveChangesAsync();
        }
    }
}
