using Infrastructure.Configuration.RedisConfiguration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Domain.Extensions.ConfigurationExtensions
{
    public static class RedisConfigurationExtension
    {
        public static IConfigurationBuilder AddRedisConfiguration(this IConfigurationBuilder configuration,
                                                                  IServiceCollection services)

        {
            var provider = services.BuildServiceProvider();
            //var source = provider.GetRequiredKeyedService<RedisConfigurationSource>(nameof(RedisConfigurationSource));
            var source = provider.GetRequiredService<RedisConfigurationSource>();
            configuration.Add(source);
            return configuration;
        }
    }
}
