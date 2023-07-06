using SprmApi.Common.Paginations;
using SprmApi.Core.Parts.Dto;

namespace SprmApi.Core.Parts
{
    /// <summary>
    /// Part version service interface
    /// </summary>
    public interface IPartVersionService
    {
        /// <summary>
        /// Get part version by part version id
        /// </summary>
        /// <param name="versionId">Part version id</param>
        /// <param name="includePart">Does part version include part entity</param>
        /// <returns></returns>
        Task<PartVersion?> GetByIdAsync(long versionId, bool includePart);

        /// <summary>
        /// Update part version by part version id
        /// </summary>
        /// <param name="id">Part version id</param>
        /// <param name="versionDTO">Update data</param>
        /// <returns></returns>
        Task UpdateAsync(long id, UpdatePartVersionDto versionDTO);

        /// <summary>
        /// Get part versions of specific part
        /// </summary>
        /// <param name="masterId">Target part id</param>
        /// <param name="input">pagination</param>
        /// <returns></returns>
        Task<IEnumerable<PartVersion>> GetPartVersions(long masterId, OffsetPaginationInput input);
    }
}
