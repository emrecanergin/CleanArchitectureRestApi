using RabbitMQ.Client;

namespace Application.RabbitMq
{
    public interface IRabbitMqService
    {
        IConnection GetConnection();
        IModel GetModel();
    }
}
