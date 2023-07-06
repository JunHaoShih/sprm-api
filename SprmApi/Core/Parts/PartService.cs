﻿using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Common.Paginations;
using SprmApi.Core.Parts.DTOs;
using SprmApi.Core.PartUsages;
using SprmApi.Core.PartUsages.DTOs;
using SprmApi.MiddleWares;
using System.Transactions;

namespace SprmApi.Core.Parts
{
    /// <summary>
    /// Part service
    /// </summary>
    public class PartService : IPartService
    {
        private readonly IPartDAO _partDAO;

        private readonly IPartVersionDAO _partVersionDAO;

        private readonly IPartUsageDAO _partUsageDAO;

        private readonly HeaderData _headerData;

        private readonly PaginationData _paginationData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="partDAO"></param>
        /// <param name="partVersionDAO"></param>
        /// <param name="partUsageDAO"></param>
        /// <param name="headerData"></param>
        /// <param name="paginationData"></param>
        public PartService(
            IPartDAO partDAO,
            IPartVersionDAO partVersionDAO,
            IPartUsageDAO partUsageDAO,
            HeaderData headerData,
            PaginationData paginationData)
        {
            _partDAO = partDAO;
            _partVersionDAO = partVersionDAO;
            _partUsageDAO = partUsageDAO;
            _headerData = headerData;
            _paginationData = paginationData;
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(long id) => await _partDAO.DeleteAsync(id);

        /// <inheritdoc/>
        public async Task<Part?> GetByNumberAsync(string number) => await _partDAO.GetByNumberAsync(number);

        /// <inheritdoc/>
        public async Task<Part?> GetByIdAsync(long id) => await _partDAO.GetByIdAsync(id);

        /// <inheritdoc/>
        public async Task<Part> InsertAsync(CreatePartDTO createPartDTO)
        {
            TransactionOptions transactionOptions = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
            {
                //await _attributeLinkDAO.GetByObjectTypeIdAsync()
                var newPart = await _partDAO.InsertAsync(createPartDTO, _headerData.JWTPayload.Subject);
                CreatePartVersionDTO firstVersion = new CreatePartVersionDTO
                {
                    MasterId = newPart.Id,
                    Version = 1,
                    IsLatest = false,
                    IsDraft = true,
                    CustomValues = createPartDTO.CustomValues,
                    Remarks = createPartDTO.Remarks,
                };
                await _partVersionDAO.InsertAsync(firstVersion.ToEntity(), _headerData.JWTPayload.Subject);
                var createdPart = await _partDAO.GetByIdAsync(newPart.Id);
                scope.Complete();
                return createdPart!;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Part>> GetByPatternAsync(string? pattern, OffsetPaginationInput input)
        {
            var parts = _partDAO.GetByPatternAsync(pattern);
            var offsetPagination = new OffsetPagination<Part>(parts, input);
            var pagedList = await offsetPagination.GetPagedListAsync();
            var header = offsetPagination.GetResponseHeader();
            _paginationData.PaginationHeader = header;
            return pagedList;
        }

        /// <inheritdoc/>
        public async Task<Part> CheckOutAsync(long partId, long? versionId = null)
        {
            TransactionOptions transactionOptions = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
            {
                Part? targetPart = await _partDAO.GetByIdAsync(partId);
                if (targetPart == null)
                {
                    throw new SPRMException(ErrorCode.DbDataNotFound, $"Part id: ${partId} does not exist!");
                }
                if (targetPart.Checkout)
                {
                    throw new SPRMException(ErrorCode.DataAlreadyCheckout, $"Part id: ${partId} already checkout!");
                }

                PartVersion? latestVersion = await _partVersionDAO.GetLatest(partId);
                if (latestVersion == null)
                {
                    throw new SPRMException(ErrorCode.LatestVersionNotFound, $"Part id: ${partId} cannot find latest version!");
                }
                IEnumerable<PartUsage> usages = await _partUsageDAO.GetByPartVersionIdAsync(latestVersion.Id, false);

                CreatePartVersionDTO createVersionDto = CreatePartVersionDTO.Parse(latestVersion);
                createVersionDto.IsLatest = false;
                createVersionDto.IsDraft = true;
                createVersionDto.Version++;
                PartVersion draftVersion = await _partVersionDAO.InsertAsync(createVersionDto.ToEntity(), _headerData.JWTPayload.Subject);
                foreach (var usage in usages)
                {
                    CreatePartUsageChildDTO createDto = CreatePartUsageChildDTO.Parse(usage);
                    await _partUsageDAO.InsertAsync(draftVersion.Id, createDto, _headerData.JWTPayload.Subject);
                }

                targetPart.Checkout = true;
                Part updatedPart = await _partDAO.UpdateAsync(targetPart, _headerData.JWTPayload.Subject);
                scope.Complete();
                return updatedPart;
            }
        }

        /// <inheritdoc/>
        public async Task<Part> CheckInAsync(long partId)
        {
            TransactionOptions transactionOptions = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
            {
                Part? targetPart = await _partDAO.GetByIdAsync(partId);
                if (targetPart == null)
                {
                    throw new SPRMException(ErrorCode.DbDataNotFound, $"Part id: ${partId} does not exist!");
                }
                if (!targetPart.Checkout)
                {
                    throw new SPRMException(ErrorCode.DataDoesNotCheckout, $"Part id: ${partId} does not checkout!");
                }

                PartVersion? latestVersion = await _partVersionDAO.GetLatest(partId);
                PartVersion? draftVersion = await _partVersionDAO.GetDraft(partId);

                if (draftVersion == null)
                {
                    throw new SPRMException(ErrorCode.DraftVersionNotFound, $"Part id: ${partId} cannt find draft version!");
                }

                if (latestVersion != null)
                {
                    draftVersion.Version = latestVersion.Version + 1;
                    // Current latest version is not latest anymore, so we mark it as not latest
                    latestVersion.IsLatest = false;
                    await _partVersionDAO.UpdateAsync(latestVersion, _headerData.JWTPayload.Subject);
                }
                // Mark draft version as latest
                draftVersion.IsLatest = true;
                draftVersion.IsDraft = false;
                await _partVersionDAO.UpdateAsync(draftVersion, _headerData.JWTPayload.Subject);

                targetPart.Checkout = false;
                Part updatedPart = await _partDAO.UpdateAsync(targetPart, _headerData.JWTPayload.Subject);
                scope.Complete();
                return updatedPart;
            }
        }

        /// <inheritdoc/>
        public async Task<Part> DiscardAsync(long partId)
        {
            TransactionOptions transactionOptions = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
            {
                Part? targetPart = await _partDAO.GetByIdAsync(partId);
                if (targetPart == null)
                {
                    throw new SPRMException(ErrorCode.DbDataNotFound, $"Part id: ${partId} does not exist!");
                }
                if (!targetPart.Checkout)
                {
                    throw new SPRMException(ErrorCode.DataDoesNotCheckout, $"Part id: ${partId} does not checkout!");
                }

                PartVersion? draftVersion = await _partVersionDAO.GetDraft(partId);
                if (draftVersion == null)
                {
                    throw new SPRMException(ErrorCode.DraftVersionNotFound, $"Part id: ${partId} cannt find draft version!");
                }

                await _partVersionDAO.DeleteAsync(draftVersion);

                targetPart.Checkout = false;
                Part updatedPart = await _partDAO.UpdateAsync(targetPart, _headerData.JWTPayload.Subject);
                scope.Complete();
                return updatedPart;
            }
        }
    }
}
