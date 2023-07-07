namespace SprmApi.Settings
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
        /// Default constructor
        /// </summary>
        public JwtSettings() { }

        /// <summary>
        /// Constructor for initialize value
        /// </summary>
        /// <param name="issuer"></param>
        /// <param name="signKey"></param>
        public JwtSettings(string issuer, string signKey)
        {
            Issuer = issuer;
            SignKey = signKey;
        }
    }
}
