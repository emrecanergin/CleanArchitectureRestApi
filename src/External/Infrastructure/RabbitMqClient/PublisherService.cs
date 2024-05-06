using Application.RabbitMq;
using Infrastructure.RabbitMq.Models;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Infrastructure.RabbitMq
{
    public class PublisherService : IPublisherService
    {
        private readonly IRabbitMqService _rabbitMqService;
        public readonly IModel _channel;
        public PublisherService(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
            _channel = _rabbitMqService.GetModel();
        }
        public void SendMessage<T>(string exchangeName, string routingKey, T message)
        {
            _channel.ExchangeDeclare(exchangeName, "direct");
            _channel.QueueDeclare(queue: $"{exchangeName}:QUEUE",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
            string data = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(data);


            _channel.BasicPublish(exchange: $"{exchangeName}:QUEUE",
                                 routingKey: routingKey,
                                 basicProperties: null,
                                 body: body);
        }
        public void SendMessage<T>(MessageConfiguration messageConfiguration, T message)
        {
            string data = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(data);

            IBasicProperties properties = _channel.CreateBasicProperties();
            properties.DeliveryMode = 2;

            _channel.BasicPublish(exchange: messageConfiguration.ExchangeName,
                                 routingKey: messageConfiguration.RoutingKey,
                                 basicProperties: properties,
                                 body: body);
        }
    }
}
