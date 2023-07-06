using SprmApi.Common.Error;
using SprmApi.Common.Exceptions;
using SprmApi.Common.Paginations;
using SprmApi.Core.Parts.DTOs;
using SprmApi.MiddleWares;
using System;

namespace SprmApi.Core.Parts
{
    /// <summary>
    /// Part version service
    /// </summary>
    public class PartVersionService : IPartVersionService
    {
        private readonly IPartVersionDAO _partVersionDAO;

        private readonly HeaderData _headerData;

        private readonly PaginationData _paginationData;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="partVersionDAO"></param>
        /// <param name="headerData"></param>
        /// <param name="paginationData"></param>
        public PartVersionService(
            IPartVersionDAO partVersionDAO,
            HeaderData headerData,
            PaginationData paginationData)
        {
            _partVersionDAO = partVersionDAO;
            _headerData = headerData;
            _paginationData = paginationData;
        }

        /// <inheritdoc/>
        public async Task<PartVersion?> GetByIdAsync(long versionId, bool includePart)
        {
            return await _partVersionDAO.GetAsync(versionId, includePart);
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(long id, UpdatePartVersionDTO versionDTO)
        {
            var targetVersion = await _partVersionDAO.GetAsync(id, false);
            if (targetVersion == null)
            {
                throw new SprmException(ErrorCode.DbDataNotFound, $"Part version id: {id} does not exist!");
            }
            targetVersion = versionDTO.ApplyUpdate(targetVersion);
            await _partVersionDAO.UpdateAsync(targetVersion, _headerData.JWTPayload.Subject);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PartVersion>> GetPartVersions(long masterId, OffsetPaginationInput input)
        {
            IQueryable<PartVersion> partVersions = _partVersionDAO.GetPartVersions(masterId);
            var offsetPagination = new OffsetPagination<PartVersion>(partVersions, input);
            var pagedList = await offsetPagination.GetPagedListAsync();
            var header = offsetPagination.GetResponseHeader();
            _paginationData.PaginationHeader = header;
            return pagedList;
        }
    }
}
