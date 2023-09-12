using StackExchange.Redis;

namespace SprmApi.Core.Redis
{
    /// <summary>
    /// Redis service interface
    /// </summary>
    public interface IRedisService
    {
        /// <summary>
        /// Get Redis database
        /// </summary>
        /// <returns></returns>
        IDatabase GetDatabase();
    }
}
