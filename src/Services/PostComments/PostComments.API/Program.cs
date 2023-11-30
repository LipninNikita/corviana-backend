using EventBusRabbitMq;
using Microsoft.EntityFrameworkCore;
using PostComments.API.Data;
using PostComments.API.Services;
using Services.Common;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionString"]));

builder.Services.AddTransient<IPostCommentService, PostCommentService>();

builder.AddRedis();

var app = builder.Build();

app.UseServiceDefaults();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    services.MigrateDbContext<AppDbContext>();
}

app.Run();
