using SprmApi.EFs;

namespace SprmApi.Core.Permissions
{
    /// <summary>
    /// User permission DAO
    /// </summary>
    public class PermissionDao : IPermissionDao
    {
        private readonly SprmContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public PermissionDao(SprmContext context)
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
    }
}
