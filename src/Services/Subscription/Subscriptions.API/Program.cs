using EventBusRabbitMq;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Subscriptions.API.Data;
using Subscriptions.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionString"]));

builder.Services.AddTransient<ISubscriptionService, SubscriptionService>();

builder.AddEventBus();

var app = builder.Build();

app.UseServiceDefaults();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    services.MigrateDbContext<AppDbContext>();
}

app.Run();