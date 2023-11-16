using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Services.Common
{
    public static class RedisExtensions
    {
        public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddSingleton(sp =>
            {
                var redisConfig = ConfigurationOptions.Parse(configuration.GetValue<string>("Cache"), true);
                var muxer = ConnectionMultiplexer.Connect(redisConfig);
                return muxer.GetDatabase();
            });
        }
    }
}
