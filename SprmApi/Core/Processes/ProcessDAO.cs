using Microsoft.EntityFrameworkCore;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Core.Parts;
using SprmApi.Core.Processes.DTOs;
using SprmApi.EFs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SprmApi.Core.Processes
{
    /// <summary>
    /// Process DAO
    /// </summary>
    public class ProcessDAO : IProcessDAO
    {
        private readonly SprmContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public ProcessDAO(SprmContext context) => _context = context;

        /// <inheritdoc/>
        public async Task<Process?> GetByNumberAsync(string number)
        {
            return await _context.Processes
                .Where(process => process.Number == number)
                .Include(process => process.ProcessType)
                .Include(process => process.MakeType)
                .SingleOrDefaultAsync();
        }

        /// <inheritdoc/>
        public IQueryable<Process> GetByPattern(string? pattern)
        {
            if (pattern == null)
            {
                return _context.Processes
                    .Include(process => process.ProcessType)
                    .Include(process => process.MakeType)
                    .OrderBy(process => process.Id)
                    .AsQueryable();
            }
            return _context.Processes
                .Where(process => EF.Functions.Like(process.Number, pattern) || EF.Functions.Like(process.Name, pattern))
                .Include(process => process.ProcessType)
                .Include(process => process.MakeType)
                .OrderBy(process => process.Id);
        }

        /// <inheritdoc/>
        public async Task<Process> Insert(CreateProcessDto createDTO, string creator)
        {
            Process? duplicateProcess = await GetByNumberAsync(createDTO.Number);
            if (duplicateProcess != null)
            {
                throw new SprmException(ErrorCode.DbInsertDuplicate, $"{duplicateProcess.Number} already exist");
            }
            Process entity = createDTO.ToEntity();
            entity.CreateUser = creator;
            entity.UpdateUser = creator;
            _context.Processes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(long id)
        {
            Process? targetProcess = await _context.Processes
                .Where(process => process.Id == id)
                .SingleOrDefaultAsync();
            if (targetProcess == null)
            {
                throw new SprmException(ErrorCode.DbDataNotFound, $"{id} not found");
            }
            _context.Processes.Remove(targetProcess);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(Process process, string updater)
        {
            process.UpdateDate = DateTime.UtcNow;
            process.UpdateUser = updater;
            _context.Processes.Update(process);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<Process?> GetAsync(long id)
        {
            return await _context.Processes
                .Where(process => process.Id == id)
                .Include(process => process.ProcessType)
                .Include(process => process.MakeType)
                .SingleOrDefaultAsync();
        }
    }
}
