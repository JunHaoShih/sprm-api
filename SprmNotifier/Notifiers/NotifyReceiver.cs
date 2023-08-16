namespace SprmNotifier.Notifiers
{
    public class NotifyReceiver : IHostedService
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="appUserService"></param>
        public NotifyReceiver(ILogger<NotifyReceiver> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task StopAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}
