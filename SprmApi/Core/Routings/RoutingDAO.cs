using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Core.Routings.DTOs;
using SprmApi.EFs;

namespace SprmApi.Core.Routings
{
    /// <summary>
    /// Routing DAO
    /// </summary>
    public class RoutingDAO : IRoutingDAO
    {
        private readonly SprmContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public RoutingDAO(SprmContext context) => _context = context;

        /// <inheritdoc/>
        public IQueryable<Routing> GetByPartId(long partId, bool includeVersion)
        {
            var routings = _context.Routings
                .Where(routing => routing.PartId == partId);
            if (includeVersion)
            {
                routings = routings.Include(routing => routing.RoutingVersions);
            }
            return routings;
        }

        /// <inheritdoc/>
        public async Task<Routing> InsertAsync(CreateRoutingDto createDTO, string creator)
        {
            Routing? duplicateRouting = _context.Routings
                .Where(routing => routing.PartId == createDTO.PartId && routing.Name == createDTO.Name)
                .SingleOrDefault();
            if (duplicateRouting != null)
            {
                throw new SprmException(ErrorCode.DbInsertDuplicate, $"{duplicateRouting.Name} already exist");
            }

            Routing entity = createDTO.ToEntity();
            entity.Checkout = true;
            entity.CreateUser = creator;
            entity.UpdateUser = creator;
            _context.Routings.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <inheritdoc/>
        public async Task<Routing?> GetByIdAsync(long routingId)
        {
            return await _context.Routings
                .Where(routing => routing.Id == routingId)
                .SingleOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<Routing> UpdateAsync(Routing routing, string modifier)
        {
            routing.UpdateDate = DateTime.UtcNow;
            routing.UpdateUser = modifier;
            EntityEntry<Routing> updatedPart = _context.Routings.Update(routing);
            await _context.SaveChangesAsync();
            return updatedPart.Entity;
        }
    }
}
