using Microsoft.EntityFrameworkCore;
using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Common.Paginations;
using SprmApi.Core.Routings.DTOs;
using SprmApi.Core.RoutingUsages;
using SprmApi.Core.RoutingUsages.DTOs;
using SprmApi.MiddleWares;
using System.Transactions;

namespace SprmApi.Core.Routings
{
    /// <summary>
    /// Routing service
    /// </summary>
    public class RoutingService : IRoutingService
    {
        private readonly IRoutingDAO _routingDAO;

        private readonly IRoutingVersionDAO _routingVersionDAO;

        private readonly IRoutingUsageDAO _routingUsageDAO;

        private readonly HeaderData _headerData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="routingDAO"></param>
        /// <param name="routingVersionDAO"></param>
        /// <param name="routingUsageDAO"></param>
        /// <param name="headerData"></param>
        public RoutingService(
            IRoutingDAO routingDAO,
            IRoutingVersionDAO routingVersionDAO,
            IRoutingUsageDAO routingUsageDAO,
            HeaderData headerData)
        {
            _routingDAO = routingDAO;
            _routingVersionDAO = routingVersionDAO;
            _routingUsageDAO = routingUsageDAO;
            _headerData = headerData;
        }

        /// <inheritdoc/>
        public OffsetPagination<RoutingDTO> GetByPartIdAsync(long partId, OffsetPaginationInput input)
        {
            IQueryable<Routing> routings = _routingDAO.GetByPartId(partId, true);
            IQueryable<RoutingDTO> dtos = routings.Select(routing => RoutingDTO.Parse(
                routing,
                routing.RoutingVersions!
                    .Where(version => version.IsLatest || version.IsDraft)
                    .OrderByDescending(version => version.IsLatest)
                    .First(),
                routing.RoutingVersions!.Where(version => version.IsDraft).SingleOrDefault())
            );
            OffsetPagination<RoutingDTO> offsetPagination = new OffsetPagination<RoutingDTO>(dtos, input);
            return offsetPagination;
        }

        /// <inheritdoc/>
        public async Task<RoutingDTO?> GetByIdAsync(long routingId)
        {
            Routing? routing = await _routingDAO.GetByIdAsync(routingId);
            if (routing == null)
            {
                return null;
            }
            RoutingVersion latest = _routingVersionDAO.GetByMasterId(routing.Id)
                .Where(version => version.IsLatest || version.IsDraft)
                .OrderByDescending(version => version.IsLatest)
                .First();
            RoutingVersion? draft = _routingVersionDAO.GetByMasterId(routing.Id)
                .Where(version => version.IsDraft)
                .SingleOrDefault();
            return RoutingDTO.Parse(routing, latest, draft);
        }

        /// <inheritdoc/>
        public async Task<RoutingDTO> InsertAsync(CreateRoutingDTO createDTO)
        {
            TransactionOptions transactionOptions = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
            {
                Routing newRouting = await _routingDAO.InsertAsync(createDTO, _headerData.JWTPayload.Subject);
                CreateRoutingVersionDTO firstVersion = new CreateRoutingVersionDTO
                {
                    MasterId = newRouting.Id,
                    Version = 1,
                    IsLatest = false,
                    IsDraft = true,
                    CustomValues = createDTO.CustomValues,
                    Remarks = createDTO.Remarks,
                };
                RoutingVersion newVersion = await _routingVersionDAO.InsertAsync(firstVersion.ToEntity(), _headerData.JWTPayload.Subject);
                scope.Complete();
                return RoutingDTO.Parse(newRouting, newVersion, newVersion);
            }
        }

        /// <inheritdoc/>
        public async Task<RoutingDTO> CheckOutAsync(long routingId, long? versionId = null)
        {
            TransactionOptions transactionOptions = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
            {
                Routing? targetRouting = await _routingDAO.GetByIdAsync(routingId);
                if (targetRouting == null)
                {
                    throw new SPRMException(ErrorCode.DbDataNotFound, $"Routing id: ${routingId} does not exist!");
                }
                if (targetRouting.Checkout)
                {
                    throw new SPRMException(ErrorCode.DataAlreadyCheckout, $"Routing id: ${routingId} already checkout!");
                }

                RoutingVersion? latestVersion = await _routingVersionDAO.GetLatest(routingId);
                if (latestVersion == null)
                {
                    throw new SPRMException(ErrorCode.LatestVersionNotFound, $"Routing id: ${routingId} cannot find latest version!");
                }

                CreateRoutingVersionDTO createVersionDto = CreateRoutingVersionDTO.Parse(latestVersion);
                createVersionDto.IsLatest = false;
                createVersionDto.IsDraft = true;
                createVersionDto.Version++;
                RoutingVersion draftVersion = await _routingVersionDAO.InsertAsync(createVersionDto.ToEntity(), _headerData.JWTPayload.Subject);
                await CopyUsages(latestVersion.Id, draftVersion.Id, null, null);

                targetRouting.Checkout = true;
                Routing updatedRouting = await _routingDAO.UpdateAsync(targetRouting, _headerData.JWTPayload.Subject);
                scope.Complete();
                return RoutingDTO.Parse(updatedRouting, latestVersion, draftVersion);
            }
        }

        private async Task CopyUsages(long latestRootId, long draftRootId, long? parentUsageId, long? newParentUsageId)
        {
            List<RoutingUsage> usages = await _routingUsageDAO
                .GetByRootVersionIdAndParentUsageId(latestRootId, parentUsageId)
                .ToListAsync();
            foreach (RoutingUsage usage in usages)
            {
                CreateRoutingUsageDTO createDto = CreateRoutingUsageDTO.Parse(usage);
                createDto.RootVersionId = draftRootId;
                createDto.ParentUsageId = newParentUsageId;
                RoutingUsage newUsage = await _routingUsageDAO.InsertAsync(createDto, _headerData.JWTPayload.Subject);
                await CopyUsages(latestRootId, draftRootId, usage.Id, newUsage.Id);
            }
        }

        /// <inheritdoc/>
        public async Task<RoutingDTO> CheckInAsync(long routingId)
        {
            TransactionOptions transactionOptions = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
            {
                Routing? targetRouting = await _routingDAO.GetByIdAsync(routingId);
                if (targetRouting == null)
                {
                    throw new SPRMException(ErrorCode.DbDataNotFound, $"Routing id: ${routingId} does not exist!");
                }
                if (!targetRouting.Checkout)
                {
                    throw new SPRMException(ErrorCode.DataDoesNotCheckout, $"Routing id: ${routingId} does not checkout!");
                }

                RoutingVersion? latestVersion = await _routingVersionDAO.GetLatest(routingId);
                RoutingVersion? draftVersion = await _routingVersionDAO.GetDraft(routingId);

                if (draftVersion == null)
                {
                    throw new SPRMException(ErrorCode.DraftVersionNotFound, $"Routing id: ${routingId} cannt find draft version!");
                }

                if (latestVersion != null)
                {
                    draftVersion.Version = latestVersion.Version + 1;
                    // Current latest version is not latest anymore, so we mark it as not latest
                    latestVersion.IsLatest = false;
                    await _routingVersionDAO.UpdateAsync(latestVersion, _headerData.JWTPayload.Subject);
                }
                // Mark draft version as latest
                draftVersion.IsLatest = true;
                draftVersion.IsDraft = false;
                await _routingVersionDAO.UpdateAsync(draftVersion, _headerData.JWTPayload.Subject);

                targetRouting.Checkout = false;
                Routing updatedRouting = await _routingDAO.UpdateAsync(targetRouting, _headerData.JWTPayload.Subject);
                scope.Complete();
                // Because draft version is our latest version, so we pass draftVersion into DTO
                return RoutingDTO.Parse(updatedRouting, draftVersion, null);
            }
        }

        /// <inheritdoc/>
        public async Task<RoutingDTO> DiscardAsync(long routingId)
        {
            TransactionOptions transactionOptions = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
            {
                Routing? targetRouting = await _routingDAO.GetByIdAsync(routingId);
                if (targetRouting == null)
                {
                    throw new SPRMException(ErrorCode.DbDataNotFound, $"Routing id: ${routingId} does not exist!");
                }
                if (!targetRouting.Checkout)
                {
                    throw new SPRMException(ErrorCode.DataDoesNotCheckout, $"Routing id: ${routingId} does not checkout!");
                }

                RoutingVersion? draftVersion = await _routingVersionDAO.GetDraft(routingId);
                if (draftVersion == null)
                {
                    throw new SPRMException(ErrorCode.DraftVersionNotFound, $"Routing id: ${routingId} cannt find draft version!");
                }

                await _routingVersionDAO.DeleteAsync(draftVersion);

                targetRouting.Checkout = false;
                Routing updatedRouting = await _routingDAO.UpdateAsync(targetRouting, _headerData.JWTPayload.Subject);
                scope.Complete();
                RoutingVersion? latestVersion = await _routingVersionDAO.GetLatest(routingId);
                return RoutingDTO.Parse(updatedRouting, latestVersion, null);
            }
        }
    }
}
