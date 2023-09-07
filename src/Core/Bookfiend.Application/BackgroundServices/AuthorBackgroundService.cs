using Bookfiend.Application.MessageBroker;
using Bookfiend.Domain;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bookfiend.Application.BackgroundServices
{
    public class AuthorBackgroundService : BackgroundService
    {
        private readonly RabbitMqClientService _rabbitMqClientService;
        private readonly ILogger<AuthorBackgroundService> _logger;
        private IModel _channel;

        public AuthorBackgroundService(RabbitMqClientService rabbitMqClientService, ILogger<AuthorBackgroundService> logger)
        {
            _rabbitMqClientService = rabbitMqClientService;
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _channel = _rabbitMqClientService.Connect();
            _channel.BasicQos(0, 1, false);

            return base.StartAsync(cancellationToken);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            _channel.BasicConsume(RabbitMqClientService.QueueName, false, consumer);
            consumer.Received += Consumer_Receieved;

            return Task.CompletedTask;

        }

        private Task Consumer_Receieved(object sender, BasicDeliverEventArgs @event)
        {
            var authorCreated = JsonSerializer.Deserialize<Author>(Encoding.UTF8.GetString(@event.Body.ToArray()));
            _logger.LogInformation("Background service receieved something from queue : " + "DELETED AUTHOR :" + authorCreated.FirstName + " " + authorCreated.LastName + " " + authorCreated.Id);
            _channel.BasicAck(@event.DeliveryTag, false);
            return Task.CompletedTask;
           
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
