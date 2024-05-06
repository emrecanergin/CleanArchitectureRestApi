using StackExchange.Redis;


namespace Infrastructure.RedisClient
{
    public class RedisOptions
    {
        public string Configuration { get; set; }
        public ConfigurationOptions ConfigurationOptions { get; set; }
        public object InstanceName { get; set; }
    }
}
