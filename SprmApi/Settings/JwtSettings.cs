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
    }
}
