using EventBusRabbitMq;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Test.API.Data;
using Test.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionString"]));

builder.AddEventBus();

builder.Services.AddTransient<ITestService, TestService>();

//builder.AddRedis();

//builder.AddGrpcServer();

var app = builder.Build();

app.UseServiceDefaults();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    services.MigrateDbContext<AppDbContext>();
}

app.Run();
