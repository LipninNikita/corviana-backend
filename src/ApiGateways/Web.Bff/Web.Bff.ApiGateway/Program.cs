using EventBusRabbitMq;
using Questions.API.Grpc.Services;
using Services.Common;
using Web.Bff.ApiGateway.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.AddEventBus();

builder.AddGrpcClient<QuestionsGrpcService.QuestionsGrpcServiceClient>(builder.Configuration["QuestionsGrpc"]);

var app = builder.Build();

app.UseServiceDefaults();

app.MapReverseProxy();
app.UseHttpsRedirection();

app.Run();