using Application.Redis;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Configuration.RedisConfiguration
{
    public class RedisConfigurationSource : IConfigurationSource
    {
        private readonly IRedisManager _redisManager;
        public RedisConfigurationSource(IRedisManager redisManager)
        {
            _redisManager = redisManager;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new RedisConfigurationProvider(_redisManager);
        }
    }
}
