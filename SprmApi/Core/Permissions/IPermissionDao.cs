namespace SprmApi.Core.Permissions
{
    /// <summary>
    /// User permission DAO interface
    /// </summary>
    public interface IPermissionDao
    {
        /// <summary>
        /// Get user permissions by user id
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns></returns>
        IQueryable<Permission> GetByUserId(long userId);
    }
}
