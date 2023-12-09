using EventBusRabbitMq;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Point.API.Data;
using Point.API.Services;
using Point.API.Events.Handler;
using Point.API.Events.Models;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionString"]));

builder.AddEventBus();

builder.Services.AddTransient<IPointTransactionService, PointTransactionService>();
builder.Services.AddTransient<QuestCompletedEventHandler>();
builder.Services.AddTransient<QuestionCompletedEventHandler>();

//builder.AddRedis();

//builder.AddGrpcServer();

var app = builder.Build();

app.UseServiceDefaults();

var bus = app.Services.GetRequiredService<IEventBus>();
bus.Subscribe<QuestCompletedEvent, QuestCompletedEventHandler>();
bus.Subscribe<QuestionCompletedEvent, QuestionCompletedEventHandler>();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    services.MigrateDbContext<AppDbContext>();
}

app.Run();
