using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RabbitMq.Models
{
    public class MessageConfiguration
    {
        public string ExchangeName { get; set; }
        public string RoutingKey { get; set; }
    }
}
