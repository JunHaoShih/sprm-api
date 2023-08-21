using Microsoft.EntityFrameworkCore;
using SprmApi.Core.Customs.Dto;
using SprmApi.EFs;
using SprmCommon.Error;
using SprmCommon.Exceptions;

namespace SprmApi.Core.Customs
{
    /// <summary>
    /// Custom attribute DAO
    /// </summary>
    public class CustomAttributeDao : ICustomAttributeDao
    {
        private readonly SprmContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public CustomAttributeDao(SprmContext context) => _context = context;

        /// <inheritdoc/>
        public async Task DeleteAsync(long id)
        {
            var targetAttr = await GetByIdAsync(id);
            if (targetAttr == null)
            {
                throw new SprmException(ErrorCode.DbDataNotFound, $"Custom attribute id: {id} does not exist");
            }
            _context.CustomAttributes.Remove(targetAttr);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CustomAttribute>> GetAllAsync()
        {
            return await _context.CustomAttributes.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<CustomAttribute?> GetByIdAsync(long id)
        {
            return await _context.CustomAttributes
                .Where(attr => attr.Id == id)
                .SingleOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<CustomAttribute?> GetByNumberAsync(string number)
        {
            return await _context.CustomAttributes
                .Where(attr => attr.Number == number)
                .SingleOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<CustomAttribute> InsertAsync(CreateCustomAttributeDto dto, string creator)
        {
            var duplicateAttr = await GetByNumberAsync(dto.Number);
            if (duplicateAttr != null)
            {
                throw new SprmException(ErrorCode.DbInsertDuplicate, $"{duplicateAttr.Number} already exist");
            }
            var entity = dto.ToEntity();
            entity.CreateUser = creator;
            entity.UpdateUser = creator;
            await _context.CustomAttributes.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(CustomAttribute attribute, string updater)
        {
            attribute.UpdateDate = DateTime.UtcNow;
            attribute.UpdateUser = updater;
            await _context.SaveChangesAsync();
        }
    }
}
