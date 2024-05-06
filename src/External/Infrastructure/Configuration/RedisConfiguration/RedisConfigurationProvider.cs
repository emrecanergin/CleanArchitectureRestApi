using Application.Redis;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Configuration.RedisConfiguration
{
    public class RedisConfigurationProvider : ConfigurationProvider
    {
        private readonly IRedisManager _redisManager;
        public RedisConfigurationProvider(IRedisManager redisManager)
        {
            _redisManager = redisManager;
        }

        public override void Load()
        {
            var redisSettings = _redisManager.GetValueFromHash("RabbitMqConfiguration");
            //RabbitMqConfiguration settings = JsonConvert.DeserializeObject<RabbitMqConfiguration>(redisSettings);

            var connectionStringEntry = redisSettings.FirstOrDefault(x => x.Name == "ConnectionString");
            var connectionString = connectionStringEntry.Value.ToString();
            Data.Add("RabbitMqConnectionString", connectionString);
        }
    }
}
