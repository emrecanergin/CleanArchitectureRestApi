using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RabbitMq.Models
{
    public enum ExchangeType
    {
        FANOUT,
        TOPIC,
        DIRECT,
        HEADER
    }
    public class ExchangeConfiguration
    {
        public string Name { get; set; }
        public ExchangeType Type { get; set; }
        public bool Durable { get; set; }
        public bool AutoDelete { get; set; }

    }
}
