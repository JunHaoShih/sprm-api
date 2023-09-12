using SprmApi.Settings;
using StackExchange.Redis;

namespace SprmApi.Core.Redis
{
    /// <summary>
    /// Redis service
    /// </summary>
    public class RedisService : IRedisService
    {
        private readonly Lazy<ConnectionMultiplexer> _lazyConnection;

        /// <summary>
        /// Redis service constructor
        /// </summary>
        /// <param name="settings"></param>
        public RedisService(RedisSettings settings)
        {
            ConfigurationOptions options = new()
            {
                User = settings.User,
                Password = settings.Password,
                AbortOnConnectFail = false,
                EndPoints = new()
                {
                    { settings.Host, 6379 }
                }
            };
            _lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(options);
            });
        }

        /// <inheritdoc/>
        public IDatabase GetDatabase()
        {
            return _lazyConnection.Value.GetDatabase();
        }
    }
}
