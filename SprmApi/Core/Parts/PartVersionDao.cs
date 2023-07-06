using Microsoft.EntityFrameworkCore;
using SprmApi.EFs;

namespace SprmApi.Core.Parts
{
    /// <summary>
    /// Part version DAO
    /// </summary>
    public class PartVersionDao : IPartVersionDao
    {
        private readonly SprmContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public PartVersionDao(SprmContext context) => _context = context;

        /// <inheritdoc/>
        public async Task<PartVersion?> GetAsync(long partVersionId, bool includePart)
        {
            PartVersion? partVersion;
            if (includePart)
            {
                partVersion = await _context.PartVersions
                    .Where(partVersion => partVersion.Id == partVersionId)
                    .Include(partVersion => partVersion.Master)
                    .SingleOrDefaultAsync();
            }
            else
            {
                partVersion = await _context.PartVersions
                    .Where(partVersion => partVersion.Id == partVersionId)
                    .SingleOrDefaultAsync();
            }
            return partVersion;
        }

        /// <inheritdoc/>
        public async Task<PartVersion> InsertAsync(PartVersion partVersion, string creator)
        {
            partVersion.CreateUser = creator;
            partVersion.UpdateUser = creator;
            await _context.PartVersions.AddAsync(partVersion);
            await _context.SaveChangesAsync();
            return partVersion;
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(PartVersion partVersion, string updator)
        {
            partVersion.UpdateDate = DateTime.UtcNow;
            partVersion.UpdateUser = updator;
            _context.PartVersions.Update(partVersion);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(PartVersion partVersion)
        {
            _context.PartVersions.Remove(partVersion);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public IQueryable<PartVersion> GetPartVersions(long masterId)
        {
            return _context.PartVersions
                .Include(version => version.Master)
                .Where(version => version.MasterId == masterId)
                .OrderByDescending(version => version.Version);
        }

        /// <inheritdoc/>
        public async Task<PartVersion?> GetLatest(long masterId)
        {
            return await _context.PartVersions
                .Where(version => version.MasterId == masterId
                    && version.IsLatest)
                .SingleOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<PartVersion?> GetDraft(long masterId)
        {
            return await _context.PartVersions
                .Where(version => version.MasterId == masterId && version.IsDraft)
                .SingleOrDefaultAsync();
        }
    }
}
