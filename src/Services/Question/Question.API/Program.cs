using Microsoft.EntityFrameworkCore;
using Question.API.Data;
using Question.API.Services;
using Services.Common;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionString"]));

builder.Services.AddTransient<IQuestionService, QuestionService>();

//builder.AddRedis();

builder.AddGrpcServer();

var app = builder.Build();

app.UseGrpcServer<QuestionsGrpc>();

app.UseServiceDefaults();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    services.MigrateDbContext<AppDbContext>();
}

app.Run();
