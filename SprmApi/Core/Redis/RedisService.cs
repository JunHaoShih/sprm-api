using SprmApi.Settings;
using StackExchange.Redis;

namespace SprmApi.Core.Redis
{
    /// <summary>
    /// Redis service
    /// </summary>
    public class RedisService : IRedisService
    {
        private readonly RedisSettings _settings;

        private readonly Lazy<ConnectionMultiplexer> _lazyConnection;

        /// <summary>
        /// Redis service constructor
        /// </summary>
        /// <param name="settings"></param>
        public RedisService(RedisSettings settings)
        {
            _settings = settings;
            ConfigurationOptions options = new()
            {
                User = _settings.User,
                Password = _settings.Password,
                AbortOnConnectFail = false,
                EndPoints = new()
                {
                    { _settings.Host, 6379 }
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
