namespace SprmAuthentication.Settings
{
    /// <summary>
    /// JWT設定值
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// Issuer
        /// </summary>
        public string Issuer { get; private set; } = null!;

        /// <summary>
        /// Encrypted key
        /// </summary>
        public string SignKey { get; private set; } = null!;

        /// <summary>
        /// Encrypted key for inner service
        /// </summary>
        public string InnerSignKey { get; private set; } = null!;

        /// <summary>
        /// Default constructor
        /// </summary>
        public JwtSettings() { }

        /// <summary>
        /// Constructor for initialize value
        /// </summary>
        /// <param name="issuer"></param>
        /// <param name="signKey"></param>
        /// <param name="innerSignKey"></param>
        public JwtSettings(string issuer, string signKey, string innerSignKey)
        {
            Issuer = issuer;
            SignKey = signKey;
            InnerSignKey = innerSignKey;
        }
    }
}
