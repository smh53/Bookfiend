using Bookfiend.Domain;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bookfiend.Application.MessageBroker
{
    public class RabbitMqPublisher : IRabbitMqPublisher
    {
        private readonly RabbitMqClientService _rabbitMqClientService;

        public RabbitMqPublisher(RabbitMqClientService rabbitMqClientService)
        {
            _rabbitMqClientService = rabbitMqClientService;
        }

        public void Publish<T>(T message)
        {
            var channel = _rabbitMqClientService.Connect();

            var bodyString = JsonSerializer.Serialize(message);
            var bodyByte = Encoding.UTF8.GetBytes(bodyString);
            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            channel.BasicPublish(exchange: RabbitMqClientService.ExchangeName, routingKey: RabbitMqClientService.RoutingEmail, basicProperties: properties, body: bodyByte);
        }

       
    }
}
