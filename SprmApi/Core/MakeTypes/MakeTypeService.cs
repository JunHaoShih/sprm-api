using SprmApi.Core.MakeTypes.DTOs;

namespace SprmApi.Core.MakeTypes
{
    /// <summary>
    /// Make type service
    /// </summary>
    public class MakeTypeService : IMakeTypeService
    {
        private readonly IMakeTypeDAO _makeTypeDAO;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="makeTypeDAO"></param>
        public MakeTypeService(IMakeTypeDAO makeTypeDAO) => _makeTypeDAO = makeTypeDAO;

        /// <inheritdoc/>
        public IQueryable<MakeTypeDto> GetAll()
        {
            IQueryable<MakeType> makeTypes = _makeTypeDAO.GetAll();
            IQueryable<MakeTypeDto> dtos = makeTypes.Select(makeType => MakeTypeDto.Parse(makeType));
            return dtos;
        }
    }
}
