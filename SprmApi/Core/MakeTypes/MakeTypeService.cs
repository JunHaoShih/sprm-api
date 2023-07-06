using SprmApi.Core.MakeTypes.Dto;

namespace SprmApi.Core.MakeTypes
{
    /// <summary>
    /// Make type service
    /// </summary>
    public class MakeTypeService : IMakeTypeService
    {
        private readonly IMakeTypeDao _makeTypeDAO;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="makeTypeDAO"></param>
        public MakeTypeService(IMakeTypeDao makeTypeDAO) => _makeTypeDAO = makeTypeDAO;

        /// <inheritdoc/>
        public IQueryable<MakeTypeDto> GetAll()
        {
            IQueryable<MakeType> makeTypes = _makeTypeDAO.GetAll();
            IQueryable<MakeTypeDto> dtos = makeTypes.Select(makeType => MakeTypeDto.Parse(makeType));
            return dtos;
        }
    }
}
