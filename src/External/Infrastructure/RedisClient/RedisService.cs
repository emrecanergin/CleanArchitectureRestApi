using Application.Redis;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Infrastructure.RedisClient
{
    public class RedisService : IRedisService
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;
        private readonly IOptions<RedisOptions> _redisOptions;

        public RedisService(IOptions<RedisOptions> redisOptions)
        {
            _redisOptions = redisOptions;
            _connectionMultiplexer = ConnectionMultiplexer.Connect("localhost:1923");
        }

        public IDatabase Database(int databaseId)
        {
            return _connectionMultiplexer.GetDatabase(databaseId);

        }
        public void FlushDatabase(int databaseId)
        {
            _connectionMultiplexer.GetServer(_redisOptions.Value.Configuration).FlushDatabase(databaseId);
        }

        public ConfigurationOptions CreateRedisConfigurationOptions()
        {
            var config = _redisOptions.Value.ConfigurationOptions;
            return config;
        }
    }
}
