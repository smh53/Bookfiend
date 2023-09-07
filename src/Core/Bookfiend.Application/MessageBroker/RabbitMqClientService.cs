using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.MessageBroker
{
    public class RabbitMqClientService : IDisposable
    {
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;
        public static string ExchangeName = "DirectExchange";
        public static string RoutingEmail = "direct-route";
        public static string QueueName = "queue-direct";
        private readonly ILogger<RabbitMqClientService> _logger;

        public RabbitMqClientService(ConnectionFactory connectionFactory, ILogger<RabbitMqClientService> logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
            
        }

        public IModel Connect()
        {
           _connection = _connectionFactory.CreateConnection();
            if(_channel is { IsOpen: true })
            {
                return _channel;
            }
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(ExchangeName, ExchangeType.Direct, true, false);
            _channel.QueueDeclare(QueueName, true,false, false, null);
            _channel.QueueBind(QueueName, ExchangeName, RoutingEmail);
            _logger.LogInformation("RabbitMq connection is successfull");

            return _channel;
           
        }
        public void Dispose()
        {
            _channel?.Close();
            _channel?.Dispose();
            _connection?.Close();
            _connection?.Dispose();

            _logger.LogInformation("RabbitMq disconnected");
        }
    }
}
