using Microsoft.EntityFrameworkCore;
using SprmApi.EFs;

namespace SprmApi.Core.ObjectTypes
{
    /// <summary>
    /// Object type DAO
    /// </summary>
    public class ObjectTypeDAO : IObjectTypeDAO
    {
        private readonly SprmContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public ObjectTypeDAO( SprmContext context )
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<ObjectType?> GetByIdAsync(SprmObjectType id)
        {
            return await _context.ObjectTypes
                .Where(x => x.Id == (long)id)
                .FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ObjectType>> GetAllAsync()
        {
            return await _context.ObjectTypes.ToListAsync();
        }
    }
}
