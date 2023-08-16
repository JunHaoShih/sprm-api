using RabbitMQ.Client;

namespace SprmApi.Core.RabbitMq
{
    /// <summary>
    /// RabbitMq service interface
    /// </summary>
    public interface IRabbitMqService
    {
        /// <summary>
        /// Create channel
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// It's your responsibility to close the channel
        /// </remarks>
        IModel CreateChannel();
    }
}
