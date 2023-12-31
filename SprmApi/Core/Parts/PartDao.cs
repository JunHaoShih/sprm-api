﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SprmApi.Core.Parts.Dto;
using SprmApi.EFs;
using SprmCommon.Error;
using SprmCommon.Exceptions;

namespace SprmApi.Core.Parts
{
    /// <summary>
    /// Part DAO
    /// </summary>
    public class PartDao : IPartDao
    {
        private readonly SprmContext _sprmContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="smpmContext"></param>
        public PartDao(SprmContext smpmContext) => _sprmContext = smpmContext;

        /// <inheritdoc/>
        public async Task DeleteAsync(long id)
        {
            Part? part = await GetByIdAsync(id);
            if (part != null)
            {
                _sprmContext.Parts.Remove(part);
                await _sprmContext.SaveChangesAsync();
            }
        }

        /// <inheritdoc/>
        public async Task<Part?> GetByIdAsync(long id)
        {
            return await _sprmContext.Parts
                .Where(x => x.Id == id)
                .Include(part => part.PartVersions!.Where(version => version.IsLatest || version.IsDraft))
                .SingleOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<Part?> GetByNumberAsync(string number)
        {
            return await _sprmContext.Parts
                .Where(x => x.Number == number)
                .Include(part => part.PartVersions!.Where(version => version.IsLatest || version.IsDraft))
                .SingleOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<Part> InsertAsync(CreatePartDto createPartDTO, string creator)
        {
            Part? duplicatePart = await GetByNumberAsync(createPartDTO.Number);
            if (duplicatePart != null)
            {
                throw new SprmException(ErrorCode.DbInsertDuplicate, $"{duplicatePart.Number} already exist");
            }
            Part entity = createPartDTO.ToEntity();
            entity.Checkout = true;
            entity.CreateUser = creator;
            entity.UpdateUser = creator;
            _sprmContext.Parts.Add(entity);
            await _sprmContext.SaveChangesAsync();
            return entity;
        }

        /// <inheritdoc/>
        public IQueryable<Part> GetByPatternAsync(string? pattern)
        {
            if (pattern == null)
            {
                return _sprmContext.Parts
                    .Include(part => part.PartVersions!.Where(version => version.IsLatest || version.IsDraft));
            }
            return _sprmContext.Parts
                .Where(part => EF.Functions.Like(part.Number, pattern) || EF.Functions.Like(part.Name, pattern))
                .Include(part => part.PartVersions!.Where(version => version.IsLatest || version.IsDraft));
        }

        /// <inheritdoc/>
        public async Task<Part> UpdateAsync(Part part, string modifier)
        {
            part.UpdateDate = DateTime.UtcNow;
            part.UpdateUser = modifier;
            EntityEntry<Part> updatedPart = _sprmContext.Parts.Update(part);
            await _sprmContext.SaveChangesAsync();
            return updatedPart.Entity;
        }
    }
}
