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
        public string Protocol { get; private set; } = null!;

        /// <summary>
        /// AMQP host
        /// </summary>
        public string Host { get; private set; } = null!;

        /// <summary>
        /// AMQP account
        /// </summary>
        public string Account { get; private set; } = null!;

        /// <summary>
        /// AMQP password
        /// </summary>
        public string Password { get; private set; } = null!;

        /// <summary>
        /// Name to notify quere
        /// </summary>
        public string NotifyQueueName { get; private set; } = null!;
    }
}
