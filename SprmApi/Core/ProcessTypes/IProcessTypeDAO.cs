namespace SprmApi.Core.ProcessTypes
{
    /// <summary>
    /// Process type DAO interface
    /// </summary>
    public interface IProcessTypeDAO
    {
        /// <summary>
        /// Get all process types
        /// </summary>
        /// <returns></returns>
        IQueryable<ProcessType> GetAll();
    }
}
