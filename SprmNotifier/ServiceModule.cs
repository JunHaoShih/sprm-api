using Autofac;
using SprmNotifier.RabbitMq;
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
            var jwtSettings = _configurationManager.GetSection("JwtSettings").Get<JwtSettings>(c => c.BindNonPublicProperties = true)!;
            builder.Register(c => jwtSettings).SingleInstance();

            var amqpSettings = _configurationManager.GetSection("AmqpSettings").Get<AmqpSettings>(c => c.BindNonPublicProperties = true)!;
            builder.Register(c => amqpSettings).SingleInstance();

            // RabbitMq
            builder.RegisterType<RabbitMqService>().As<IRabbitMqService>().SingleInstance();
        }
    }
}
