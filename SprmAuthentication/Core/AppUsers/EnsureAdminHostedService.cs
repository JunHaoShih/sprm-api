namespace SprmAuthentication.Core.AppUsers
{
    /// <summary>
    /// 此HostedService確保
    /// </summary>
    public class EnsureAdminHostedService : IHostedService
    {
        private readonly ILogger _logger;

        private readonly IAppUserService _appUserService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="appUserService"></param>
        public EnsureAdminHostedService(ILogger<EnsureAdminHostedService> logger, IAppUserService appUserService)
        {
            _logger = logger;
            _appUserService = appUserService;
        }

        /// <summary>
        /// Start hosted service, ensure admin account is created
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("EnsureAdminHostedService is starting");
            _appUserService.CreateDefaultAdminAsync();
            return Task.CompletedTask;
        }

        /// <summary>
        /// Stop hosted service, currently not used
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("EnsureAdminHostedService is stopping");
            return Task.CompletedTask;
        }
    }
}
