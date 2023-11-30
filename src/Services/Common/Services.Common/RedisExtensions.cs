using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Retry;
using StackExchange.Redis;
using System.Net.Sockets;

namespace Services.Common
{
    public static class RedisExtensions
    {
        public static WebApplicationBuilder AddRedis(this WebApplicationBuilder builder)
        {
            var redisConfig = ConfigurationOptions.Parse(builder.Configuration.GetValue<string>("Cache"), true);

            var policy = RetryPolicy.Handle<RedisConnectionException>()
             .Or<RedisServerException>()
             .WaitAndRetry(10, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            policy.Execute(() =>
            {
                var muxer = ConnectionMultiplexer.Connect(redisConfig);
                var database = muxer.GetDatabase();
                builder.Services.AddSingleton(database);
            });

            return builder;
        }
    }
}
