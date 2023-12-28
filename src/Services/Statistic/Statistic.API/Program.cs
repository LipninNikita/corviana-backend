using Statistic.API.Data;
using Statistic.API.Events.Handler;
using Statistic.API.Events.Models;
using Statistic.API.Services;
using EventBusRabbitMq;
using Microsoft.EntityFrameworkCore;
using Services.Common;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionString"]));

builder.AddEventBus();

builder.Services.AddTransient<IStatisticService, StatisticService>();

var app = builder.Build();

app.UseServiceDefaults();

var bus = app.Services.GetRequiredService<IEventBus>();
bus.Subscribe<QuestionAnsweredSuccessfulEvent, QuestionAnsweredSuccessfulEventHandler>();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    services.MigrateDbContext<AppDbContext>();
}

app.Run();
