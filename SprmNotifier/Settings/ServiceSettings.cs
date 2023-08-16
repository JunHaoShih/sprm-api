namespace SprmNotifier.Settings
{
    public class ServiceSettings
    {
        /// <summary>
        /// JWT settings
        /// </summary>
        public JwtSettings JwtSettings { get; private set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public ServiceSettings() { }

        /// <summary>
        /// Constructor for initialize value
        /// </summary>
        /// <param name="jwtSettings"></param>
        public ServiceSettings(JwtSettings jwtSettings)
        {
            JwtSettings = jwtSettings;
        }
    }
}
