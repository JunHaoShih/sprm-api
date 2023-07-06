namespace SprmApi.Core.ObjectTypes
{
    /// <summary>
    /// Object type DAO interface
    /// </summary>
    public interface IObjectTypeDao
    {
        /// <summary>
        /// Get all object types
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ObjectType>> GetAllAsync();

        /// <summary>
        /// Get object type by id
        /// </summary>
        /// <param name="id">Object type id</param>
        /// <returns></returns>
        Task<ObjectType?> GetByIdAsync(SprmObjectType id);
    }
}
