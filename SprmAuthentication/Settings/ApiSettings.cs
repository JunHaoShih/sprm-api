namespace SprmAuthentication.Settings
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
        /// <param name="jwtSettings"></param>
        public ApiSettings(
            string connectionString,
            string signKey,
            string defaultAdmin,
            string defaultPassword,
            JwtSettings jwtSettings
        )
        {
            ConnectionString = connectionString;
            SignKey = signKey;
            DefaultAdmin = defaultAdmin;
            DefaultPassword = defaultPassword;
            JwtSettings = jwtSettings;
        }
    }
}
