using Microsoft.EntityFrameworkCore;
using Services.Common;
using Quest.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionString"]));

//builder.Services.AddTransient<IQuestionService, QuestionService>();

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
