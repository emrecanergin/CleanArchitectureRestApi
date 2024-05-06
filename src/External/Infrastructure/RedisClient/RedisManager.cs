using Application.Redis;
using StackExchange.Redis;
using System.Text.Json;

namespace Infrastructure.RedisClient
{
    public class RedisManager : IRedisManager
    {
        private readonly IRedisService _redisService;
        public RedisManager(IRedisService redisService)
        {
            _redisService = redisService;
        }
        public void Add(string key, string value)
        {
            _redisService.Database(0).StringSet(key, value);
        }
        public void Add(string key, string value, TimeSpan expireTime)
        {
            _redisService.Database(0).StringSet(key, value, expireTime);
        }
        public bool Any(string key)
        {
            return _redisService.Database(0).KeyExists(key);
        }

        public void Clear()
        {
            _redisService.FlushDatabase(0);
        }

        public T GetJsonData<T>(string key)
        {
            if (Any(key))
            {
                var jsonData = _redisService.Database(0).StringGet(key);
                return JsonSerializer.Deserialize<T>(jsonData);
            }
            return default;
        }

        public HashEntry[] GetValueFromHash(string key)
        {
            return _redisService.Database(0).HashGetAll(key);
        }
        public string GetValue(string key)
        {
            return _redisService.Database(0).StringGet(key);
        }

        public void Remove(string key)
        {
            _redisService.Database(0).KeyDelete(key);
        }
    }
}
