using SprmApi.EFs;

namespace SprmApi.Core.MakeTypes
{
    /// <summary>
    /// Make type DAO
    /// </summary>
    public class MakeTypeDao : IMakeTypeDao
    {
        private readonly SprmContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public MakeTypeDao(SprmContext context) => _context = context;

        /// <inheritdoc/>
        public IQueryable<MakeType> GetAll()
        {
            return _context.MakeTypes
                .OrderBy(makeType => makeType.Id)
                .AsQueryable();
        }
    }
}
