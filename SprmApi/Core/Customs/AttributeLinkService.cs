using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Core.Customs.Dto;
using SprmApi.Core.ObjectTypes;
using SprmApi.MiddleWares;
using System;
using System.Transactions;

namespace SprmApi.Core.Customs
{
    /// <summary>
    /// Attribute link service
    /// </summary>
    public class AttributeLinkService : IAttributeLinkService
    {
        private readonly IAttributeLinkDao _attributeLinkDAO;

        private readonly IObjectTypeDao _objectTypeDAO;

        private readonly ICustomAttributeDao _attributeDAO;

        private readonly HeaderData _headerData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="attributeLinkDAO"></param>
        /// <param name="objectTypeDAO"></param>
        /// <param name="attributeDAO"></param>
        /// <param name="headerData"></param>
        public AttributeLinkService(
            IAttributeLinkDao attributeLinkDAO,
            IObjectTypeDao objectTypeDAO,
            ICustomAttributeDao attributeDAO,
            HeaderData headerData)
        {
            _attributeLinkDAO = attributeLinkDAO;
            _objectTypeDAO = objectTypeDAO;
            _attributeDAO = attributeDAO;
            _headerData = headerData;
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(DeleteAttributeLinksDto deleteDTO)
        {
            TransactionOptions transactionOptions = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
            {
                await ValidateLinksAsync(deleteDTO.ObjectTypeId, deleteDTO.AttributeIds);

                foreach (var attributeId in deleteDTO.AttributeIds)
                {
                    var targetAttributeLink = await _attributeLinkDAO.Get(deleteDTO.ObjectTypeId, attributeId);
                    if (targetAttributeLink == null)
                    {
                        throw new SprmException(ErrorCode.DbDataNotFound,
                            $"Attribute link [objectTypeId: {deleteDTO.ObjectTypeId}, attributeId: {attributeId}] does not exist");
                    }
                    await _attributeLinkDAO.DeleteAsync(targetAttributeLink.Id);
                }

                scope.Complete();
            }
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(long id) => await _attributeLinkDAO.DeleteAsync(id);

        /// <inheritdoc/>
        public async Task<IEnumerable<AttributeLink>> GetByObjectTypeIdAsync(SprmObjectType objectTypeId)
        {
            var objectType = await _objectTypeDAO.GetByIdAsync(objectTypeId);
            if (objectType == null)
            {
                throw new SprmException(ErrorCode.DbDataNotFound, $"Object type id: {objectTypeId} does not exist");
            }
            return await _attributeLinkDAO.GetByObjectTypeAsync(objectTypeId);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<AttributeLink>> Insert(CreateAttributeLinksDto createDTO)
        {
            TransactionOptions transactionOptions = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
            {
                List<AttributeLink> newLinks = new List<AttributeLink>();

                await ValidateLinksAsync(createDTO.ObjectTypeId, createDTO.AttributeIds);

                foreach (var attributeId in createDTO.AttributeIds)
                {
                    var newLink = await _attributeLinkDAO.InsertAsync(createDTO.ObjectTypeId, attributeId, _headerData.JWTPayload.Subject);
                    newLinks.Add(newLink);
                }
                
                scope.Complete();
                return newLinks;
            }
        }

        /// <summary>
        /// 驗證Attribute links是否存在
        /// </summary>
        /// <param name="objectTypeId">物件類別id</param>
        /// <param name="attributeIds">自訂屬性id清單</param>
        /// <returns></returns>
        /// <exception cref="SprmException"></exception>
        private async Task ValidateLinksAsync(SprmObjectType objectTypeId, IEnumerable<long> attributeIds)
        {
            var objectType = await _objectTypeDAO.GetByIdAsync(objectTypeId);
            if (objectType == null)
            {
                throw new SprmException(ErrorCode.DbDataNotFound, $"Object type id: {objectTypeId} does not exist");
            }
            foreach (var attributeId in attributeIds)
            {
                var attribute = await _attributeDAO.GetByIdAsync(attributeId);
                if (attribute == null)
                {
                    throw new SprmException(ErrorCode.DbDataNotFound, $"Custom attribute id: {attributeId} does not exist");
                }
            }
        }
    }
}
