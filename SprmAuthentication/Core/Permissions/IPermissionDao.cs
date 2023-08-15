namespace SprmAuthentication.Core.Permissions
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

        /// <summary>
        /// Insert permission
        /// </summary>
        /// <param name="permission">New permission</param>
        /// <param name="creator">Create username</param>
        /// <returns></returns>
        Task<Permission> InsertAsync(Permission permission, string creator);

        /// <summary>
        /// Update permission
        /// </summary>
        /// <param name="permission">Update data</param>
        /// <param name="updater">Update username</param>
        /// <returns></returns>
        Task UpdateAsync(Permission permission, string updater);
    }
}
