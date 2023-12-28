using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace Services.Common
{
    public static class GrpcExtensions
    {
        public static WebApplicationBuilder AddGrpcServer(this WebApplicationBuilder builder)
        {
            builder.Services.AddGrpc(options =>
            {
                options.EnableDetailedErrors = true;
            });

            builder.WebHost.UseKestrel(options =>
            {
                options.Listen(IPAddress.Any, 80); // HTTP requests
                options.Listen(IPAddress.Any, 81, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http2; // gRPC requests
                });
            });

            return builder;
        }

        public static WebApplication UseGrpcServer<TServer>(this WebApplication app) where TServer : class
        {
            app.MapGrpcService<TServer>();

            return app;
        }
        public static WebApplicationBuilder AddGrpcClient<TClient>(this WebApplicationBuilder builder, string grpcConnString) where TClient : class
        {
            builder.Services.AddGrpc(options =>
            {
                options.EnableDetailedErrors = true;
            });

            builder.Services.AddGrpcClient<TClient>(options =>
            {
                options.Address = new Uri(grpcConnString);
            });          

            return builder;
        }
    }
}
