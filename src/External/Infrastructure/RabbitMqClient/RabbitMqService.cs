using Application.RabbitMq;
using Infrastructure.RabbitMq.Models;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace Infrastructure.RabbitMq
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly IConfiguration _configuration;
        public RabbitMqService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IConnection GetConnection()
        {
            string connectionString = _configuration.GetValue<string>("RabbitMqConnectionString").ToString();
            var factory = new ConnectionFactory()
            {
                Uri = new Uri(connectionString),
            };

            return factory.CreateConnection();
        }

        public IModel GetModel()
        {
            return GetConnection().CreateModel();
        }

        public void DeclareExchange(IConnection connection, ExchangeConfiguration exchangeConfiguration)
        {
            using (var channel = this.GetModel())
            {
                channel.ExchangeDeclare(exchange: exchangeConfiguration.Name,
                                        type: exchangeConfiguration.Type.ToString(),
                                        durable: exchangeConfiguration.Durable,
                                        autoDelete: exchangeConfiguration.AutoDelete,
                                        arguments: null);
            }
        }
    }
}
