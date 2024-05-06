using Infrastructure.RabbitMq.Models;


namespace Application.RabbitMq
{
    public interface IPublisherService
    {
        void SendMessage<T>(MessageConfiguration messageConfiguration, T message);
        void SendMessage<T>(string exchangeName, string routingKey, T message);
    }
}
