using RabbitMQ.Client;
using SprmApi.Settings;

namespace SprmApi.Core.RabbitMq
{
    /// <summary>
    /// RabbitMq service
    /// </summary>
    public class RabbitMqService : IRabbitMqService
    {
        private readonly IConnection _connection;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="settings"></param>
        public RabbitMqService(AmqpSettings settings)
        {
            var factory = new ConnectionFactory
            {
                HostName = settings.Host,
                UserName = settings.Account,
                Password = settings.Password,
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
