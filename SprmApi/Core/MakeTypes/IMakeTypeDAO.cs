namespace SprmApi.Core.MakeTypes
{
    /// <summary>
    /// Make type DAO interface
    /// </summary>
    public interface IMakeTypeDAO
    {
        /// <summary>
        /// Get all make types
        /// </summary>
        /// <returns></returns>
        IQueryable<MakeType> GetAll();
    }
}
