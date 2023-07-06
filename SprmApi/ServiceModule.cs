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

            builder.RegisterType<JwtService>();

            // Register AppUser related
            builder.RegisterType<AppUserDao>().As<IAppUserDao>().InstancePerLifetimeScope();
            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();

            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();

            // Register Part related
            builder.RegisterType<PartDao>().As<IPartDao>().InstancePerLifetimeScope();
            builder.RegisterType<PartVersionDao>().As<IPartVersionDao>().InstancePerLifetimeScope();
            builder.RegisterType<PartService>().As<IPartService>().InstancePerLifetimeScope();
            builder.RegisterType<PartVersionService>().As<IPartVersionService>().InstancePerLifetimeScope();

            // Custom attributes
            builder.RegisterType<CustomAttributeDao>().As<ICustomAttributeDao>().InstancePerLifetimeScope();
            builder.RegisterType<CustomAttributeService>().As<ICustomAttributeService>().InstancePerLifetimeScope();

            // Object types
            builder.RegisterType<ObjectTypeDao>().As<IObjectTypeDao>().InstancePerLifetimeScope();
            builder.RegisterType<ObjectTypeService>().As<IObjectTypeService>().InstancePerLifetimeScope();

            // Attribute links
            builder.RegisterType<AttributeLinkDao>().As<IAttributeLinkDao>().InstancePerLifetimeScope();
            builder.RegisterType<AttributeLinkService>().As<IAttributeLinkService>().InstancePerLifetimeScope();

            // Part usages
            builder.RegisterType<PartUsageDao>().As<IPartUsageDao>().InstancePerLifetimeScope();
            builder.RegisterType<PartUsageService>().As<IPartUsageService>().InstancePerLifetimeScope();

            // Routing
            builder.RegisterType<RoutingDao>().As<IRoutingDao>().InstancePerLifetimeScope();
            builder.RegisterType<RoutingService>().As<IRoutingService>().InstancePerLifetimeScope();
            builder.RegisterType<RoutingVersionDao>().As<IRoutingVersionDao>().InstancePerLifetimeScope();
            builder.RegisterType<RoutingVersionService>().As<IRoutingVersionService>().InstancePerLifetimeScope();

            // Process
            builder.RegisterType<ProcessDao>().As<IProcessDao>().InstancePerLifetimeScope();
            builder.RegisterType<ProcessService>().As<IProcessService>().InstancePerLifetimeScope();

            // Process type
            builder.RegisterType<ProcessTypeDao>().As<IProcessTypeDao>().InstancePerLifetimeScope();
            builder.RegisterType<ProcessTypeService>().As<IProcessTypeService>().InstancePerLifetimeScope();

            // Make type
            builder.RegisterType<MakeTypeDao>().As<IMakeTypeDao>().InstancePerLifetimeScope();
            builder.RegisterType<MakeTypeService>().As<IMakeTypeService>().InstancePerLifetimeScope();

            // Routing usage
            builder.RegisterType<RoutingUsageDao>().As<IRoutingUsageDao>();
            builder.RegisterType<RoutingUsageService>().As<IRoutingUsageService>();
        }
    }
}
