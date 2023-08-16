using Microsoft.EntityFrameworkCore;
using SprmCommon.Error;
using SprmCommon.Exceptions;
using SprmApi.Core.PartUsages.Dto;
using SprmApi.EFs;
using System.Text.Json;

namespace SprmApi.Core.PartUsages
{
    /// <summary>
    /// Part usage DAO
    /// </summary>
    public class PartUsageDao : IPartUsageDao
    {
        private readonly SprmContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public PartUsageDao(SprmContext context) => _context = context;

        /// <inheritdoc/>
        public async Task<PartUsage?> GetAsync(long parentPartVersionId, long childPartId)
        {
            return await _context.PartUsages
                .Where(partUsage => partUsage.ParentId == parentPartVersionId && partUsage.ChildId == childPartId)
                .SingleOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<PartUsage?> GetAsync(long id, bool includeSubChildren)
        {
            IQueryable<PartUsage> target = _context.PartUsages
                .Where(partUsage => partUsage.Id == id);
            if (includeSubChildren)
            {
                target = target.Include(usage => usage.Child)
                    .ThenInclude(part => part!.PartVersions!.Where(version => version.IsLatest || version.IsDraft))
                    .ThenInclude(version => version.PartUsages);
            }
            return await target.SingleOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PartUsage>> GetByPartVersionIdAsync(long parentPartVersionId, bool includeSubChildren)
        {
            IQueryable<PartUsage> query = _context.PartUsages
                .Where(usage => usage.ParentId == parentPartVersionId);
            if (includeSubChildren)
            {
                query = query.Include(usage => usage.Child)
                    .ThenInclude(part => part!.PartVersions!.Where(version => version.IsLatest || version.IsDraft))
                    .ThenInclude(version => version.PartUsages);
            }
            return await query.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<PartUsage> InsertAsync(long parentPartVersionId, CreatePartUsageChildDto childDTO, string creator)
        {
            var duplicateUsage = await GetAsync(parentPartVersionId, childDTO.PartId);
            if (duplicateUsage != null)
            {
                throw new SprmException(ErrorCode.DbInsertDuplicate,
                    $"PartUsage parent id: {parentPartVersionId}, child id: {childDTO.PartId} already exist");
            }
            var entity = new PartUsage
            {
                ParentId = parentPartVersionId,
                ChildId = childDTO.PartId,
                Quantity = childDTO.Quantity,
                Remarks = childDTO.Remarks,
                CustomValues = JsonSerializer.SerializeToDocument(childDTO.CustomValues),
            };
            entity.CreateUser = creator;
            entity.UpdateUser = creator;
            _context.PartUsages.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(long id)
        {
            var targetUsage = await GetAsync(id, false);
            if (targetUsage == null)
            {
                throw new SprmException(ErrorCode.DbDataNotFound,
                    $"PartUsage id {id} does not exist");
            }
            _context.PartUsages.Remove(targetUsage);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(PartUsage entity, string updator)
        {
            entity.UpdateDate = DateTime.UtcNow;
            entity.UpdateUser = updator;
            _context.PartUsages.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
