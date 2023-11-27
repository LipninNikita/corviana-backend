using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Services.Common
{
    public static class RedisExtensions
    {
        public static WebApplicationBuilder AddRedis(this WebApplicationBuilder builder)
        {
            var redisConfig = ConfigurationOptions.Parse(builder.Configuration.GetValue<string>("Cache"), true);
            var muxer = ConnectionMultiplexer.Connect(redisConfig);
            var database = muxer.GetDatabase();
            builder.Services.AddSingleton(database);

            return builder;
        }
    }
}
