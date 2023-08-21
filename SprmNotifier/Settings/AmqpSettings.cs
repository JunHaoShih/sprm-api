namespace SprmNotifier.Settings
{
    /// <summary>
    /// AMQP settings
    /// </summary>
    public class AmqpSettings
    {
        /// <summary>
        /// AMQP protocol
        /// </summary>
        public string Protocol { get; init; } = null!;

        /// <summary>
        /// AMQP host
        /// </summary>
        public string Host { get; init; } = null!;

        /// <summary>
        /// AMQP account
        /// </summary>
        public string Account { get; init; } = null!;

        /// <summary>
        /// AMQP password
        /// </summary>
        public string Password { get; init; } = null!;

        /// <summary>
        /// Name to notify quere
        /// </summary>
        public string NotifyQueueName { get; init; } = null!;
    }
}
