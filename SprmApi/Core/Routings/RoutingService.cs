using Microsoft.EntityFrameworkCore;
using SprmApi.Common.Paginations;
using SprmApi.Core.Parts;
using SprmApi.Core.Routings.Dto;
using SprmApi.Core.RoutingUsages;
using SprmApi.Core.RoutingUsages.Dto;
using SprmApi.MiddleWares;
using SprmCommon.Error;
using SprmCommon.Exceptions;
using System.Transactions;

namespace SprmApi.Core.Routings
{
    /// <summary>
    /// Routing service
    /// </summary>
    public class RoutingService : IRoutingService
    {
        private readonly IRoutingDao _routingDAO;

        private readonly IRoutingVersionDao _routingVersionDAO;

        private readonly IRoutingUsageDao _routingUsageDAO;

        private readonly IPartDao _partDAO;

        private readonly HeaderData _headerData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="routingDAO"></param>
        /// <param name="routingVersionDAO"></param>
        /// <param name="routingUsageDAO"></param>
        /// <param name="partDAO"></param>
        /// <param name="headerData"></param>
        public RoutingService(
            IRoutingDao routingDAO,
            IRoutingVersionDao routingVersionDAO,
            IRoutingUsageDao routingUsageDAO,
            IPartDao partDAO,
            HeaderData headerData)
        {
            _routingDAO = routingDAO;
            _routingVersionDAO = routingVersionDAO;
            _routingUsageDAO = routingUsageDAO;
            _partDAO = partDAO;
            _headerData = headerData;
        }

        /// <inheritdoc/>
        public OffsetPagination<RoutingDto> GetByPartIdAsync(long partId, OffsetPaginationInput input)
        {
            IQueryable<Routing> routings = _routingDAO.GetByPartId(partId, true);
            IQueryable<RoutingDto> dtos = routings.Select(routing => RoutingDto.Parse(
                routing,
                routing.RoutingVersions!
                    .Where(version => version.IsLatest || version.IsDraft)
                    .OrderByDescending(version => version.IsLatest)
                    .First(),
                routing.RoutingVersions!.SingleOrDefault(version => version.IsDraft))
            );
            OffsetPagination<RoutingDto> offsetPagination = new OffsetPagination<RoutingDto>(dtos, input);
            return offsetPagination;
        }

        /// <inheritdoc/>
        public async Task<RoutingDto?> GetByIdAsync(long routingId)
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
            return RoutingDto.Parse(routing, latest, draft);
        }

        /// <inheritdoc/>
        public async Task<RoutingDto> InsertAsync(CreateRoutingDto createDTO)
        {
            TransactionOptions transactionOptions = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
            {
                Part? targetPart = await _partDAO.GetByIdAsync(createDTO.PartId);
                if (targetPart == null)
                {
                    throw new SprmException(ErrorCode.DbDataNotFound, $"Part id: ${createDTO.PartId} does not exist!");
                }
                Routing newRouting = await _routingDAO.InsertAsync(createDTO, _headerData.JWTPayload.Subject);
                CreateRoutingVersionDto firstVersion = new()
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
                return RoutingDto.Parse(newRouting, newVersion, newVersion);
            }
        }

        /// <inheritdoc/>
        public async Task<RoutingDto> CheckOutAsync(long routingId, long? versionId = null)
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
                    throw new SprmException(ErrorCode.DbDataNotFound, $"Routing id: ${routingId} does not exist!");
                }
                if (targetRouting.Checkout)
                {
                    throw new SprmException(ErrorCode.DataAlreadyCheckout, $"Routing id: ${routingId} already checkout!");
                }

                RoutingVersion? latestVersion = await _routingVersionDAO.GetLatest(routingId);
                if (latestVersion == null)
                {
                    throw new SprmException(ErrorCode.LatestVersionNotFound, $"Routing id: ${routingId} cannot find latest version!");
                }

                CreateRoutingVersionDto createVersionDto = CreateRoutingVersionDto.Parse(latestVersion);
                createVersionDto.IsLatest = false;
                createVersionDto.IsDraft = true;
                createVersionDto.Version++;
                RoutingVersion draftVersion = await _routingVersionDAO.InsertAsync(createVersionDto.ToEntity(), _headerData.JWTPayload.Subject);
                await CopyUsages(latestVersion.Id, draftVersion.Id, null, null);

                targetRouting.Checkout = true;
                Routing updatedRouting = await _routingDAO.UpdateAsync(targetRouting, _headerData.JWTPayload.Subject);
                scope.Complete();
                return RoutingDto.Parse(updatedRouting, latestVersion, draftVersion);
            }
        }

        private async Task CopyUsages(long latestRootId, long draftRootId, long? parentUsageId, long? newParentUsageId)
        {
            List<RoutingUsage> usages = await _routingUsageDAO
                .GetByRootVersionIdAndParentUsageId(latestRootId, parentUsageId)
                .ToListAsync();
            foreach (RoutingUsage usage in usages)
            {
                CreateRoutingUsageDto createDto = CreateRoutingUsageDto.Parse(usage);
                createDto.RootVersionId = draftRootId;
                createDto.ParentUsageId = newParentUsageId;
                RoutingUsage newUsage = await _routingUsageDAO.InsertAsync(createDto, _headerData.JWTPayload.Subject);
                await CopyUsages(latestRootId, draftRootId, usage.Id, newUsage.Id);
            }
        }

        /// <inheritdoc/>
        public async Task<RoutingDto> CheckInAsync(long routingId)
        {
            TransactionOptions transactionOptions = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
            {
                Routing targetRouting = await GetRoutingById(routingId);

                RoutingVersion? latestVersion = await _routingVersionDAO.GetLatest(routingId);
                RoutingVersion? draftVersion = await _routingVersionDAO.GetDraft(routingId);

                if (draftVersion == null)
                {
                    throw new SprmException(ErrorCode.DraftVersionNotFound, $"Routing id: ${routingId} cannt find draft version!");
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
                return RoutingDto.Parse(updatedRouting, draftVersion, null);
            }
        }

        private async Task<Routing> GetRoutingById(long routingId)
        {
            Routing? targetRouting = await _routingDAO.GetByIdAsync(routingId);
            if (targetRouting == null)
            {
                throw new SprmException(ErrorCode.DbDataNotFound, $"Routing id: ${routingId} does not exist!");
            }
            if (!targetRouting.Checkout)
            {
                throw new SprmException(ErrorCode.DataDoesNotCheckout, $"Routing id: ${routingId} does not checkout!");
            }
            return targetRouting;
        }

        /// <inheritdoc/>
        public async Task<RoutingDto> DiscardAsync(long routingId)
        {
            TransactionOptions transactionOptions = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
            {
                Routing targetRouting = await GetRoutingById(routingId);

                RoutingVersion? draftVersion = await _routingVersionDAO.GetDraft(routingId);
                if (draftVersion == null)
                {
                    throw new SprmException(ErrorCode.DraftVersionNotFound, $"Routing id: ${routingId} cannt find draft version!");
                }

                await _routingVersionDAO.DeleteAsync(draftVersion);

                targetRouting.Checkout = false;
                Routing updatedRouting = await _routingDAO.UpdateAsync(targetRouting, _headerData.JWTPayload.Subject);
                scope.Complete();
                RoutingVersion? latestVersion = await _routingVersionDAO.GetLatest(routingId);
                if (latestVersion == null)
                {
                    throw new SprmException(ErrorCode.DbError, $"Something went wrong");
                }
                return RoutingDto.Parse(updatedRouting, latestVersion, null);
            }
        }
    }
}
