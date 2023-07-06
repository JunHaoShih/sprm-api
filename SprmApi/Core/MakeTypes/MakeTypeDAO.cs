﻿using SprmApi.EFs;

namespace SprmApi.Core.MakeTypes
{
    /// <summary>
    /// Make type DAO
    /// </summary>
    public class MakeTypeDAO : IMakeTypeDAO
    {
        private readonly SprmContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public MakeTypeDAO(SprmContext context) => _context = context;

        /// <inheritdoc/>
        public IQueryable<MakeType> GetAll()
        {
            return _context.MakeTypes
                .OrderBy(makeType => makeType.Id)
                .AsQueryable();
        }
    }
}
