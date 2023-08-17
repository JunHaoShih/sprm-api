using System.Text;
using System.Text.Json;
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

        private readonly IRabbitMqService _mqService;

        private readonly AmqpSettings _settings;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="rabbitMqService"></param>
        /// <param name="settings"></param>
        public NotifyReceiver(ILogger<NotifyReceiver> logger, IRabbitMqService rabbitMqService, AmqpSettings settings)
        {
            _logger = logger;
            _mqService = rabbitMqService;
            _settings = settings;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            IModel channel = _mqService.CreateChannel();

            channel.QueueDeclare(
                queue: _settings.NotifyQueueName,
                durable: true,
                exclusive: false,
                autoDelete: false
            );

            EventingBasicConsumer consumer = new(channel);

            consumer.Received += (sender, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                string json = Encoding.UTF8.GetString(body);
                MqPayload<string>? payload = JsonSerializer.Deserialize<MqPayload<string>>(json);

                if (payload == null)
                {
                    _logger.LogError("Amqp payload is null!");
                    // TODO handle exception
                    channel.BasicNack(
                        deliveryTag: ea.DeliveryTag,
                        multiple: false,
                        requeue: true
                    );
                    return;
                }

                // TODO use SignalR to send message
                channel.BasicAck(
                    deliveryTag: ea.DeliveryTag,
                    multiple: false
                );
            };

            channel.BasicConsume(_settings.NotifyQueueName, false, consumer);

            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}
