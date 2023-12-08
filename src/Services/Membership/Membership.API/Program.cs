using EventBusRabbitMq;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using System;
using Membership.API.Data;
using Sberbank.NetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionString"]));

builder.AddEventBus();

//builder.Services.AddTransient<IAnswerService, AnswerService>();

//builder.AddRedis();

//builder.AddGrpcServer();

builder.Services.AddSingleton(new SberbankClient(builder.Configuration["Sber:Username"], builder.Configuration["Sber:Password"], true));

var app = builder.Build();

app.UseServiceDefaults();

//var bus = app.Services.GetRequiredService<IEventBus>();
//bus.Subscribe<QuestionCreatedEvent, QuestionCreatedEventHandler>();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    services.MigrateDbContext<AppDbContext>();
}

app.Run();
