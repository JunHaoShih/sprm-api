using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SprmCommon.Amqp;
using SprmNotifier.RabbitMq;
using SprmNotifier.Settings;

namespace SprmNotifier.Notifiers
{
    public class NotifyReceiver : IHostedService
    {
        private readonly ILogger _logger;

        private readonly IHubContext<NotifierHub> _hubContext;

        private readonly AmqpSettings _settings;

        private readonly IModel _channel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="rabbitMqService"></param>
        /// <param name="hubContext"></param>
        /// <param name="settings"></param>
        public NotifyReceiver(
            ILogger<NotifyReceiver> logger,
            IRabbitMqService rabbitMqService,
            IHubContext<NotifierHub> hubContext,
            AmqpSettings settings
        )
        {
            _logger = logger;
            _hubContext = hubContext;
            _settings = settings;
            _channel = rabbitMqService.CreateChannel();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            _channel.QueueDeclare(
                queue: _settings.NotifyQueueName,
                durable: true,
                exclusive: false,
                autoDelete: false
            );

            EventingBasicConsumer consumer = new(_channel);

            consumer.Received += (sender, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                string json = Encoding.UTF8.GetString(body);
                MqPayload<string>? payload = JsonSerializer.Deserialize<MqPayload<string>>(json);

                if (payload == null)
                {
                    _logger.LogError("Amqp payload is null!");
                    _channel.BasicNack(
                        deliveryTag: ea.DeliveryTag,
                        multiple: false,
                        requeue: true
                    );
                    return;
                }

                payload.TargetGroups.ForEach(group =>
                {
                    _hubContext.Clients.Group(group).SendAsync("notify", payload);
                });
                _logger.LogInformation("Signalr send complete!");
                _channel.BasicAck(
                    deliveryTag: ea.DeliveryTag,
                    multiple: false
                );
            };

            _channel.BasicConsume(_settings.NotifyQueueName, false, consumer);

            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _channel.Close();

            return Task.CompletedTask;
        }
    }
}
