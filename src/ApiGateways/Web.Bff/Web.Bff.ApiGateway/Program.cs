using Microsoft.OpenApi.Models;
using Services.Common;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.AddRedis();

var app = builder.Build();

app.UseServiceDefaults();

app.MapReverseProxy();
app.UseHttpsRedirection();

app.Run();