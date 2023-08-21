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
        public string ConnectionString { get; init; } = null!;

        /// <summary>
        /// Password sign key
        /// </summary>
        public string SignKey { get; init; } = null!;

        /// <summary>
        /// 預設Admin
        /// </summary>
        public string DefaultAdmin { get; init; } = null!;

        /// <summary>
        /// 預設Admin password
        /// </summary>
        public string DefaultPassword { get; init; } = null!;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ApiSettings() { }

        /// <summary>
        /// Constructor for initialize value
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="signKey"></param>
        /// <param name="defaultAdmin"></param>
        /// <param name="defaultPassword"></param>
        public ApiSettings(
            string connectionString,
            string signKey,
            string defaultAdmin,
            string defaultPassword
        )
        {
            ConnectionString = connectionString;
            SignKey = signKey;
            DefaultAdmin = defaultAdmin;
            DefaultPassword = defaultPassword;
        }
    }
}
