using Autofac;
using SprmApi.Core.AppUsers;
using SprmApi.Core.Auth;
using SprmApi.Core.Customs;
using SprmApi.Core.MakeTypes;
using SprmApi.Core.ObjectTypes;
using SprmApi.Core.Parts;
using SprmApi.Core.PartUsages;
using SprmApi.Core.Processes;
using SprmApi.Core.ProcessTypes;
using SprmApi.Core.Routings;
using SprmApi.Core.RoutingUsages;
using SprmApi.MiddleWares;
using SprmApi.Settings;

namespace SprmApi
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
            var apiSettings = _configurationManager.GetSection("ApiSettings").Get<ApiSettings>(c => c.BindNonPublicProperties = true);
            builder.Register(c => apiSettings).SingleInstance();

            builder.RegisterType<HeaderData>().InstancePerLifetimeScope();
            builder.RegisterType<PaginationData>().InstancePerLifetimeScope();

            builder.RegisterType<JWTService>();

            // Register AppUser related
            builder.RegisterType<AppUserDAO>().As<IAppUserDAO>().InstancePerLifetimeScope();
            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();

            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();

            // Register Part related
            builder.RegisterType<PartDAO>().As<IPartDAO>().InstancePerLifetimeScope();
            builder.RegisterType<PartVersionDAO>().As<IPartVersionDAO>().InstancePerLifetimeScope();
            builder.RegisterType<PartService>().As<IPartService>().InstancePerLifetimeScope();
            builder.RegisterType<PartVersionService>().As<IPartVersionService>().InstancePerLifetimeScope();

            // Custom attributes
            builder.RegisterType<CustomAttributeDAO>().As<ICustomAttributeDAO>().InstancePerLifetimeScope();
            builder.RegisterType<CustomAttributeService>().As<ICustomAttributeService>().InstancePerLifetimeScope();

            // Object types
            builder.RegisterType<ObjectTypeDAO>().As<IObjectTypeDAO>().InstancePerLifetimeScope();
            builder.RegisterType<ObjectTypeService>().As<IObjectTypeService>().InstancePerLifetimeScope();

            // Attribute links
            builder.RegisterType<AttributeLinkDAO>().As<IAttributeLinkDAO>().InstancePerLifetimeScope();
            builder.RegisterType<AttributeLinkService>().As<IAttributeLinkService>().InstancePerLifetimeScope();

            // Part usages
            builder.RegisterType<PartUsageDAO>().As<IPartUsageDAO>().InstancePerLifetimeScope();
            builder.RegisterType<PartUsageService>().As<IPartUsageService>().InstancePerLifetimeScope();

            // Routing
            builder.RegisterType<RoutingDAO>().As<IRoutingDAO>().InstancePerLifetimeScope();
            builder.RegisterType<RoutingService>().As<IRoutingService>().InstancePerLifetimeScope();
            builder.RegisterType<RoutingVersionDAO>().As<IRoutingVersionDAO>().InstancePerLifetimeScope();
            builder.RegisterType<RoutingVersionService>().As<IRoutingVersionService>().InstancePerLifetimeScope();

            // Process
            builder.RegisterType<ProcessDAO>().As<IProcessDAO>().InstancePerLifetimeScope();
            builder.RegisterType<ProcessService>().As<IProcessService>().InstancePerLifetimeScope();

            // Process type
            builder.RegisterType<ProcessTypeDAO>().As<IProcessTypeDAO>().InstancePerLifetimeScope();
            builder.RegisterType<ProcessTypeService>().As<IProcessTypeService>().InstancePerLifetimeScope();

            // Make type
            builder.RegisterType<MakeTypeDAO>().As<IMakeTypeDAO>().InstancePerLifetimeScope();
            builder.RegisterType<MakeTypeService>().As<IMakeTypeService>().InstancePerLifetimeScope();

            // Routing usage
            builder.RegisterType<RoutingUsageDAO>().As<IRoutingUsageDAO>();
            builder.RegisterType<RoutingUsageService>().As<IRoutingUsageService>();
        }
    }
}
