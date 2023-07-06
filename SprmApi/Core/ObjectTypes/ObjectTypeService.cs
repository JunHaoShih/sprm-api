namespace SprmApi.Core.ObjectTypes
{
    /// <summary>
    /// Object type service
    /// </summary>
    public class ObjectTypeService : IObjectTypeService
    {
        private readonly IObjectTypeDAO _objectTypeDAO;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="objectTypeDAO"></param>
        public ObjectTypeService(IObjectTypeDAO objectTypeDAO)
        {
            _objectTypeDAO = objectTypeDAO;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ObjectType>> GetAllAsync()
        {
            return await _objectTypeDAO.GetAllAsync();
        }
    }
}
