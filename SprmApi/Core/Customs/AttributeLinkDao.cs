using Microsoft.EntityFrameworkCore;
using SprmCommon.Error;
using SprmCommon.Exceptions;
using SprmApi.Core.ObjectTypes;
using SprmApi.EFs;

namespace SprmApi.Core.Customs
{
    /// <summary>
    /// Attribute link DAO
    /// </summary>
    public class AttributeLinkDao : IAttributeLinkDao
    {
        private readonly SprmContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public AttributeLinkDao(SprmContext context) => _context = context;

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
        public async Task<AttributeLink?> Get(SprmObjectType objectType, long attributeId)
        {
            return await _context.AttributeLinks
                .Where(link => link.ObjectTypeId == (long)objectType && link.AttributeId == attributeId)
                .Include(link => link.Attribute)
                .FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<AttributeLink>> GetByObjectTypeAsync(SprmObjectType objectType)
        {
            var links = await _context.AttributeLinks
                .Where(link => link.ObjectTypeId == (long)objectType)
                .Include(link => link.Attribute)
                .ToListAsync();
            return links;
        }

        /// <inheritdoc/>
        public async Task<AttributeLink> InsertAsync(SprmObjectType objectType, long attributeId, string creator)
        {
            var duplicateLink = await Get(objectType, attributeId);
            if (duplicateLink != null)
            {
                throw new SprmException(ErrorCode.DbInsertDuplicate, $"link already exist");
            }
            var entity = new AttributeLink
            {
                AttributeId = attributeId,
                ObjectTypeId = (long)objectType,
                CreateUser = creator,
                UpdateUser = creator
            };
            _context.AttributeLinks.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
