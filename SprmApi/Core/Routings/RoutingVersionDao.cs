using Microsoft.EntityFrameworkCore;
using SprmApi.EFs;

namespace SprmApi.Core.Routings
{
    /// <summary>
    /// Routing version DAO
    /// </summary>
    public class RoutingVersionDao : IRoutingVersionDao
    {
        private readonly SprmContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public RoutingVersionDao(SprmContext context) => _context = context;

        /// <inheritdoc/>
        public async Task<RoutingVersion> InsertAsync(RoutingVersion routeVersion, string creator)
        {
            routeVersion.CreateUser = creator;
            routeVersion.UpdateUser = creator;
            await _context.RoutingVersions.AddAsync(routeVersion);
            await _context.SaveChangesAsync();
            return routeVersion;
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(RoutingVersion routeVersion)
        {
            _context.RoutingVersions.Remove(routeVersion);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public IQueryable<RoutingVersion> GetByMasterId(long masterId)
        {
            return _context.RoutingVersions
                .Where(r => r.MasterId == masterId)
                .Include(r => r.Master)
                .OrderByDescending(version => version.Version)
                .AsQueryable();
        }

        /// <inheritdoc/>
        public async Task<RoutingVersion?> GetAsync(long id)
        {
            return await _context.RoutingVersions
                .Where(r => r.Id == id)
                .Include(r => r.Master)
                .SingleOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<RoutingVersion?> GetLatest(long masterId)
        {
            return await _context.RoutingVersions
                .Where(version => version.MasterId == masterId
                    && version.IsLatest)
                .Include(r => r.Master)
                .SingleOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<RoutingVersion?> GetDraft(long masterId)
        {
            return await _context.RoutingVersions
                .Where(version => version.MasterId == masterId && version.IsDraft)
                .Include(r => r.Master)
                .SingleOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(RoutingVersion routingVersion, string updator)
        {
            routingVersion.UpdateDate = DateTime.UtcNow;
            routingVersion.UpdateUser = updator;
            _context.RoutingVersions.Update(routingVersion);
            await _context.SaveChangesAsync();
        }
    }
}
