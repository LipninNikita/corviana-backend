using EventBusRabbitMq;
using Interaction.API.Data;
using Interaction.API.Events.Handlers;
using Interaction.API.Events.Models;
using Interaction.API.Services;
using Microsoft.EntityFrameworkCore;
using Services.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionString"]));

builder.AddServiceDefaults();
builder.AddGrpcServer();

builder.Services.AddTransient<ILikeService, LikeService>();
builder.Services.AddTransient<IViewService, ViewService>();

builder.Services.AddTransient<HelloMsgHandler>();

builder.AddEventBus();

var app = builder.Build();

var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<HelloMsg, HelloMsgHandler>();

app.UseServiceDefaults();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    services.MigrateDbContext<AppDbContext>();
}

app.Run();