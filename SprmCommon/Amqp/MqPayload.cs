namespace SprmCommon.Amqp
{
    /// <summary>
    /// Generic Mq payload
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MqPayload<T>
    {
        /// <summary>
        /// Determine how severe your notify should be
        /// </summary>
        public NotifyLevel NotifyLevel { get; set; }

        /// <summary>
        /// Your notification type
        /// </summary>
        public NotifyType NotifyType { get; set; }

        /// <summary>
        /// Groups you want to notify
        /// </summary>
        /// <remarks>Username is also a group, which only contains that user</remarks>
        public List<string> TargetGroups { get; set; } = new();

        /// <summary>
        /// Payload content. Contains any message you want to pass
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
