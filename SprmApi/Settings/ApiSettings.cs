namespace SprmApi.Settings
{
    /// <summary>
    /// Api設定值
    /// </summary>
    public class ApiSettings
    {
        /// <summary>
        /// Database connection string
        /// </summary>
        public string ConnectionString { get; private set; } = null!;

        /// <summary>
        /// Password sign key
        /// </summary>
        public string SignKey { get; private set; } = null!;

        /// <summary>
        /// 預設Admin
        /// </summary>
        public string DefaultAdmin { get; private set; } = null!;

        /// <summary>
        /// 預設Admin password
        /// </summary>
        public string DefaultPassword { get; private set; } = null!;

        /// <summary>
        /// JWT settings
        /// </summary>
        public JwtSettings JwtSettings { get; private set; } = null!;
    }
}
