using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Common.Paginations;
using SprmApi.Core.Processes.DTOs;
using SprmApi.MiddleWares;
using System.Transactions;

namespace SprmApi.Core.Processes
{
    /// <summary>
    /// Process service
    /// </summary>
    public class ProcessService : IProcessService
    {
        private readonly IProcessDAO _processDAO;

        private readonly HeaderData _headerData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="processDAO"></param>
        /// <param name="headerData"></param>
        public ProcessService(
            IProcessDAO processDAO,
            HeaderData headerData)
        {
            _processDAO = processDAO;
            _headerData = headerData;
        }

        /// <inheritdoc/>
        public OffsetPagination<ProcessDTO> GetByPattern(string? pattern, OffsetPaginationInput input)
        {
            var processes = _processDAO.GetByPattern(pattern);
            var dtos = processes.Select(process => ProcessDTO.Parse(process));
            OffsetPagination<ProcessDTO> offsetPagination = new(dtos, input);
            return offsetPagination;
        }

        /// <inheritdoc/>
        public async Task<ProcessDTO> InsertAsync(CreateProcessDTO createDTO)
        {
            TransactionOptions transactionOptions = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
            {
                Process createdProcess = await _processDAO.Insert(createDTO, _headerData.JWTPayload.Subject);
                Process? joinedProcess = await _processDAO.GetByNumberAsync(createdProcess.Number);
                if (joinedProcess != null)
                {
                    scope.Complete();
                    return ProcessDTO.Parse(joinedProcess);
                }
                throw new SprmException(ErrorCode.DbError, "Cannot find process after insert success");
            }
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(long id)
        {
            await _processDAO.DeleteAsync(id);
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(long id, UpdateProcessDTO updateDTO)
        {
            var targetProcess = await _processDAO.GetAsync(id);
            if (targetProcess == null)
            {
                throw new SprmException(ErrorCode.DbDataNotFound, $"Process id: {id} does not exist!");
            }
            targetProcess = updateDTO.ApplyUpdate(targetProcess);
            await _processDAO.UpdateAsync(targetProcess, _headerData.JWTPayload.Subject);
        }

        /// <inheritdoc/>
        public async Task<ProcessDTO?> GetAsync(long id)
        {
            Process? targetProcess = await _processDAO.GetAsync(id);
            if (targetProcess != null)
            {
                return ProcessDTO.Parse(targetProcess);
            }
            return null;
        }
    }
}
