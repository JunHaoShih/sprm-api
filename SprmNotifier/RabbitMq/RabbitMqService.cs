using RabbitMQ.Client;
using SprmNotifier.Settings;

namespace SprmNotifier.RabbitMq
{
    /// <summary>
    /// RabbitMq service
    /// </summary>
    public class RabbitMqService : IRabbitMqService
    {
        private readonly AmqpSettings _settings;

        private readonly IConnection _connection;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="settings"></param>
        public RabbitMqService(AmqpSettings settings)
        {
            _settings = settings;
            var factory = new ConnectionFactory
            {
                HostName = _settings.Host,
                UserName = _settings.Account,
                Password = _settings.Password,
            };
            _connection = factory.CreateConnection();
        }

        /// <inheritdoc/>
        public IModel CreateChannel()
        {
            return _connection.CreateModel();
        }

        /// <summary>
        /// Destructer
        /// </summary>
        ~RabbitMqService()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
