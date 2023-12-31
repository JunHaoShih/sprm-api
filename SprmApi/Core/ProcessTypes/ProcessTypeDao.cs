﻿using SprmApi.EFs;

namespace SprmApi.Core.ProcessTypes
{
    /// <summary>
    /// Process type DAO
    /// </summary>
    public class ProcessTypeDao : IProcessTypeDao
    {
        private readonly SprmContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public ProcessTypeDao(SprmContext context) => _context = context;

        /// <inheritdoc/>
        public IQueryable<ProcessType> GetAll()
        {
            return _context.ProcessTypes
                .OrderBy(processType => processType.Id)
                .AsQueryable();
        }
    }
}
