namespace SprmApi.Core.Parts
{
    /// <summary>
    /// Part version DAO interface
    /// </summary>
    public interface IPartVersionDao
    {
        /// <summary>
        /// Insert new part version
        /// </summary>
        /// <param name="partVersion">New part version</param>
        /// <param name="creator">creator username</param>
        /// <returns></returns>
        Task<PartVersion> InsertAsync(PartVersion partVersion, string creator);

        /// <summary>
        /// Get part version by part version id
        /// </summary>
        /// <param name="partVersionId">Part version id</param>
        /// <param name="includePart">Should part entity being included</param>
        /// <returns></returns>
        Task<PartVersion?> GetAsync(long partVersionId, bool includePart);

        /// <summary>
        /// Update part version by part version id
        /// </summary>
        /// <param name="partVersion">Updated part version</param>
        /// <param name="updator">Update user name</param>
        /// <returns></returns>
        Task UpdateAsync(PartVersion partVersion, string updator);

        /// <summary>
        /// Get latest version of specific part
        /// </summary>
        /// <param name="masterId">Part id</param>
        /// <returns></returns>
        Task<PartVersion?> GetLatest(long masterId);

        /// <summary>
        /// Get draft version of specific part
        /// </summary>
        /// <param name="masterId"></param>
        /// <returns></returns>
        Task<PartVersion?> GetDraft(long masterId);

        /// <summary>
        /// Delete part version
        /// </summary>
        /// <param name="partVersion">Delete part version</param>
        /// <returns></returns>
        Task DeleteAsync(PartVersion partVersion);

        /// <summary>
        /// Get all part versions of specific part
        /// </summary>
        /// <param name="masterId">Target part id</param>
        /// <returns></returns>
        IQueryable<PartVersion> GetPartVersions(long masterId);
    }
}
