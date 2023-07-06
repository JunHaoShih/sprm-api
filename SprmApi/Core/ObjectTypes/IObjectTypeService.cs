namespace SprmApi.Core.ObjectTypes
{
    /// <summary>
    /// Object type service interface
    /// </summary>
    public interface IObjectTypeService
    {
        /// <summary>
        /// Get all object types
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ObjectType>> GetAllAsync();
    }
}
