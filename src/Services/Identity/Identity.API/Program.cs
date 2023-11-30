using Identity.API.Data.Models;
using Identity.API.Services.Login;
using Identity.API.Services.User;
using Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Common;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionString"]));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.AddRedis();

builder.AddGrpcServer();

var app = builder.Build();

app.UseServiceDefaults();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    services.MigrateDbContext<AppDbContext>();
}

app.Run();
