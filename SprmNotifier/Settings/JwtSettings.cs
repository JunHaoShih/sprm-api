namespace SprmNotifier.Settings
{
    /// <summary>
    /// JWT設定值
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// Encrypted key
        /// </summary>
        public string SignKey { get; init; } = null!;

        /// <summary>
        /// Default constructor
        /// </summary>
        public JwtSettings() { }

        /// <summary>
        /// Constructor for initialize value
        /// </summary>
        /// <param name="signKey"></param>
        public JwtSettings(string signKey)
        {
            SignKey = signKey;
        }
    }
}
