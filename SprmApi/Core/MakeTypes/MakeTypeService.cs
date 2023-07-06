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
        public IQueryable<MakeTypeDTO> GetAll()
        {
            IQueryable<MakeType> makeTypes = _makeTypeDAO.GetAll();
            IQueryable<MakeTypeDTO> dtos = makeTypes.Select(makeType => MakeTypeDTO.Parse(makeType));
            return dtos;
        }
    }
}
