using SprmApi.EFs;

namespace SprmApi.Core.ProcessTypes
{
    /// <summary>
    /// Process type DAO
    /// </summary>
    public class ProcessTypeDAO : IProcessTypeDAO
    {
        private readonly SPRMContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public ProcessTypeDAO(SPRMContext context) => _context = context;

        /// <inheritdoc/>
        public IQueryable<ProcessType> GetAll()
        {
            return _context.ProcessTypes
                .OrderBy(processType => processType.Id)
                .AsQueryable();
        }
    }
}
