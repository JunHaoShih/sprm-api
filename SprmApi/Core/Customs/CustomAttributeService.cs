using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Core.Customs.DTOs;
using SprmApi.MiddleWares;

namespace SprmApi.Core.Customs
{
    /// <summary>
    /// Custom attribute service
    /// </summary>
    public class CustomAttributeService : ICustomAttributeService
    {
        private readonly ICustomAttributeDAO _attributeDAO;

        private readonly HeaderData _headerData;

        /// Constructor
        public CustomAttributeService(ICustomAttributeDAO attributeDAO, HeaderData headerData)
        {
            _attributeDAO = attributeDAO;
            _headerData = headerData;
        }

        /// <inheritdoc/>
        public Task DeleteAsync(long id)
        {
            return _attributeDAO.DeleteAsync(id);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CustomAttribute>> GetAllAsync() => await _attributeDAO.GetAllAsync();

        /// <inheritdoc/>
        public async Task<CustomAttribute> InsertAsync(CreateCustomAttributeDTO dto)
        {
            return await _attributeDAO.InsertAsync(dto, _headerData.JWTPayload.Subject);
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(long id, UpdateCustomAttributeDTO attribute)
        {
            var targetAttribute = await _attributeDAO.GetByIdAsync(id);
            if (targetAttribute == null) {
                throw new SPRMException(ErrorCode.DbDataNotFound, $"Custom attribute id: {id} does not exist!");
            }
            targetAttribute = attribute.ApplyUpdate(targetAttribute);
            await _attributeDAO.UpdateAsync(targetAttribute, _headerData.JWTPayload.Subject);
        }
    }
}
