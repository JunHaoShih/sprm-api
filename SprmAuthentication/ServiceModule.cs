using Autofac;
using SprmAuthentication.Settings;

namespace SprmAuthentication
{
    public class ServiceModule : Module
    {
        private readonly ConfigurationManager _configurationManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configurationManager"></param>
        public ServiceModule(ConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        /// <summary>
        /// Register here
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            // Load settings file to object
            ApiSettings apiSettings = _configurationManager.GetSection("ApiSettings").Get<ApiSettings>(c => c.BindNonPublicProperties = true)!;
            builder.Register(c => apiSettings).SingleInstance();
        }
    }
}
