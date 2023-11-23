using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;
using Services.Common;
using Web.Bff.ApiGateway;

var builder = WebApplication.CreateBuilder(args);
//builder.Configuration.AddJsonFile("ocelot.json");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
//builder.Services.AddOcelot();
//builder.Services.AddSwaggerForOcelot(builder.Configuration, (x) =>
//{
//    x.GenerateDocsDocsForGatewayItSelf(opt =>
//      {
//          opt.GatewayDocsTitle = "My Gateway";
//          opt.GatewayDocsOpenApiInfo = new()
//          {
//              Title = "My Gateway",
//              Version = "v1",
//          };
//      });
//});

var app = builder.Build();

//app.UseSwaggerForOcelotUI(opt =>
//{
//    opt.DownstreamSwaggerHeaders = new[]
//    {
//        new KeyValuePair<string, string>("Auth-Key", "AuthValue")
//    };
//});

app.MapReverseProxy();

app.MapGet("/testing", () => Results.Ok("It's working"));

//app.UseSwagger();

//await app.UseOcelot();

app.Run();