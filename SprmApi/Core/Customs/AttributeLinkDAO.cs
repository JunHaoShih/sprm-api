using Microsoft.EntityFrameworkCore;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Core.ObjectTypes;
using SprmApi.EFs;

namespace SprmApi.Core.Customs
{
    /// <summary>
    /// Attribute link DAO
    /// </summary>
    public class AttributeLinkDAO : IAttributeLinkDAO
    {
        private readonly SPRMContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public AttributeLinkDAO(SPRMContext context) => _context = context;

        /// <inheritdoc/>
        public async Task DeleteAsync(long id)
        {
            var targetLink = await _context.AttributeLinks.Where(link => link.Id == id).FirstOrDefaultAsync();
            if (targetLink == null)
            {
                throw new SprmException(ErrorCode.DbDataNotFound, $"Attribute link id: {id} does not exist");
            }
            _context.AttributeLinks.Remove(targetLink);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<AttributeLink?> Get(SprmObjectType objectTypeId, long attributeId)
        {
            return await _context.AttributeLinks
                .Where(link => link.ObjectTypeId == (long)objectTypeId && link.AttributeId == attributeId)
                .Include(link => link.Attribute)
                .FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<AttributeLink>> GetByObjectTypeIdAsync(SprmObjectType objectTypeId)
        {
            var links = await _context.AttributeLinks
                .Where(link => link.ObjectTypeId == (long)objectTypeId)
                .Include(link => link.Attribute)
                .ToListAsync();
            return links;
        }

        /// <inheritdoc/>
        public async Task<AttributeLink> Insert(SprmObjectType objectTypeId, long attributeId, string creator)
        {
            var duplicateLink = await Get(objectTypeId, attributeId);
            if (duplicateLink != null)
            {
                throw new SprmException(ErrorCode.DbInsertDuplicate, $"link already exist");
            }
            var entity = new AttributeLink
            {
                AttributeId = attributeId,
                ObjectTypeId = (long)objectTypeId,
            };
            entity.CreateUser = creator;
            entity.UpdateUser = creator;
            _context.AttributeLinks.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
