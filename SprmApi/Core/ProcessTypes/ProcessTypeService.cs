using SprmApi.Core.ProcessTypes.Dto;

namespace SprmApi.Core.ProcessTypes
{
    /// <summary>
    /// Process type service
    /// </summary>
    public class ProcessTypeService : IProcessTypeService
    {
        private readonly IProcessTypeDao _processTypeDAO;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="processTypeDAO"></param>
        public ProcessTypeService(IProcessTypeDao processTypeDAO)
        {
            _processTypeDAO = processTypeDAO;
        }

        /// <inheritdoc/>
        public IQueryable<ProcessTypeDto> GetAll()
        {
            IQueryable<ProcessType> processTypes = _processTypeDAO.GetAll();
            IQueryable<ProcessTypeDto> processTypeDTOs = processTypes.Select(processType => ProcessTypeDto.Parse(processType));
            return processTypeDTOs;
        }
    }
}
