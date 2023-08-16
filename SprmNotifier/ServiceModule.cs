using Autofac;
using SprmNotifier.Settings;

namespace SprmNotifier
{
    /// <summary>
    /// Autofac IoC registration
    /// </summary>
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
            var serviceSettings = _configurationManager.GetSection("ServiceSettings").Get<ServiceSettings>(c => c.BindNonPublicProperties = true)!;
            builder.Register(c => serviceSettings).SingleInstance();
        }
    }
}
