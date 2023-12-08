using Answer.API.Data;
using Answer.API.Events.Handler;
using Answer.API.Events.Models;
using Answer.API.Services;
using EventBusRabbitMq;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionString"]));

builder.AddEventBus();

builder.Services.AddTransient<IAnswerService, AnswerService>();

builder.Services.AddTransient<QuestionCreatedEventHandler>();

//builder.AddRedis();

//builder.AddGrpcServer();

var app = builder.Build();

app.UseServiceDefaults();

var bus = app.Services.GetRequiredService<IEventBus>();
bus.Subscribe<QuestionCreatedEvent, QuestionCreatedEventHandler>();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    services.MigrateDbContext<AppDbContext>();
}

app.Run();
