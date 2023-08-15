using Autofac;
using SprmAuthentication.Core.AppUsers;
using SprmAuthentication.Core.Auth;
using SprmAuthentication.Core.Permissions;
using SprmAuthentication.Settings;
using SprmCommon.MiddleWares;

namespace SprmAuthentication
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
            ApiSettings apiSettings = _configurationManager.GetSection("ApiSettings").Get<ApiSettings>(c => c.BindNonPublicProperties = true)!;
            builder.Register(c => apiSettings).SingleInstance();

            builder.RegisterType<HeaderData>().InstancePerLifetimeScope();
            builder.RegisterType<PaginationData>().InstancePerLifetimeScope();

            // Register AppUser related
            builder.RegisterType<AppUserDao>().As<IAppUserDao>().InstancePerLifetimeScope();
            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();

            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<JwtService>().As<IJwtService>();

            // Permission
            builder.RegisterType<PermissionDao>().As<IPermissionDao>();
            builder.RegisterType<PermissionService>().As<IPermissionService>();
        }
    }
}
