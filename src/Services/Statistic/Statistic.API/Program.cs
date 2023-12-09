using EventBusRabbitMq;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Statistic.API.Data;
using Statistic.API.Events.Handler;
using Statistic.API.Events.Models;
using Statistic.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionString"]));

builder.Services.AddTransient<IStatisticService, StatisticService>();
builder.Services.AddTransient<QuestionCompletedEventHandler>();

builder.AddEventBus();

//builder.AddRedis();

//builder.AddGrpcServer();

var app = builder.Build();

app.UseServiceDefaults();

var bus = app.Services.GetRequiredService<IEventBus>();
bus.Subscribe<QuestionCompeletedEvent, QuestionCompletedEventHandler>();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    services.MigrateDbContext<AppDbContext>();
}

app.Run();
