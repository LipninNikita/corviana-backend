using EventBusRabbitMq;
using EventBusRabbitMq.Models;
using MediaStorage.API.Data;
using MediaStorage.API.Events;
using MediaStorage.API.Services;
using Microsoft.EntityFrameworkCore;
using Services.Common;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionString"]));

builder.Services.AddTransient<IImageService, ImageService>();

builder.Services.AddTransient<PostCreatedEventHandler>();

builder.AddEventBus();

var app = builder.Build();

app.UseServiceDefaults();

var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<PostCreatedEvent, PostCreatedEventHandler>();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    services.MigrateDbContext<AppDbContext>();
}

app.Run();