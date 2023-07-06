using Microsoft.EntityFrameworkCore;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Core.RoutingUsages.Dto;
using SprmApi.EFs;

namespace SprmApi.Core.RoutingUsages
{
    /// <summary>
    /// Routing usage DAO
    /// </summary>
    public class RoutingUsageDao : IRoutingUsageDao
    {
        private readonly SprmContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public RoutingUsageDao(SprmContext context) => _context = context;

        /// <inheritdoc/>
        public async Task DeleteAsync(long id)
        {
            RoutingUsage? targetUsage = await _context.RoutingUsages
                .Where(usage => usage.Id == id)
                .SingleOrDefaultAsync();

            if (targetUsage == null)
            {
                throw new SprmException(ErrorCode.DbDataNotFound, $"Routing usage id: ${id} not found!");
            }
            _context.RoutingUsages.Remove(targetUsage);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<RoutingUsage?> GetAsync(long id)
        {
            return await _context.RoutingUsages
                .Where(usage => usage.Id == id)
                .Include(usage => usage.Process)
                .SingleOrDefaultAsync();
        }

        /// <inheritdoc/>
        public IQueryable<RoutingUsage> GetByRootVersionId(long rootId)
        {
            return _context.RoutingUsages
                .Where(usage => usage.RootVersionId == rootId)
                .Include(usage => usage.Process)
                .OrderBy(usage => usage.Number)
                .AsQueryable();
        }

        /// <inheritdoc/>
        public IQueryable<RoutingUsage> GetByRootVersionIdAndParentUsageId(long rootId, long? parentUsageId)
        {
            return _context.RoutingUsages
                .Where(usage => usage.RootVersionId == rootId && usage.ParentUsageId == parentUsageId)
                .Include(usage => usage.Process)
                .OrderBy(usage => usage.Number)
                .AsQueryable();
        }

        /// <inheritdoc/>
        public async Task<RoutingUsage> InsertAsync(CreateRoutingUsageDto createDto, string creater)
        {
            RoutingUsage? duplicateUsage = await _context.RoutingUsages
                .Where(usage => usage.Number == createDto.Number && usage.RootVersionId == createDto.RootVersionId)
                .SingleOrDefaultAsync();

            if (duplicateUsage != null)
            {
                throw new SprmException(ErrorCode.DbInsertDuplicate, $"Routing usage number ${createDto.Number} already exist");
            }
            var entity = createDto.ToEntity();
            entity.CreateUser = creater;
            entity.UpdateUser = creater;
            _context.RoutingUsages.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(RoutingUsage entity, string updator)
        {
            entity.UpdateDate = DateTime.UtcNow;
            entity.UpdateUser = updator;
            _context.RoutingUsages.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
