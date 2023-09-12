namespace SprmApi.Settings
{
    /// <summary>
    /// Redis settings
    /// </summary>
    public class RedisSettings
    {
        /// <summary>
        /// Redis host
        /// </summary>
        public string Host { get; init; } = null!;

        /// <summary>
        /// Redis user
        /// </summary>
        public string User { get; init; } = null!;

        /// <summary>
        /// Redis password
        /// </summary>
        public string Password { get; init; } = null!;
    }
}
