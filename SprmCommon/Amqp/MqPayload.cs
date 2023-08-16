namespace SprmCommon.Amqp
{
    /// <summary>
    /// Generic Mq payload
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MqPayload<T>
    {
        public NotifyLevel NotifyLevel { get; set; }

        public NotifyType NotifyType { get; set; }

        /// <summary>
        /// Payload content
        /// </summary>
        public T? Content { get; set; }
    }

    public enum NotifyLevel
    {
        Unknown = 0,
        CommonNotify = 1,
        WarningNotify = 2,
        ErrorNotify = 3,
    }

    public enum NotifyType
    {
        Unknown = 0,
        PermissionChanged = 1,
    }
}
