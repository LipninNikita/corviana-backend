using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddReverseProxy()
//    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
//var app = builder.Build();
//app.MapReverseProxy();
//app.Run();

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ocelot.json");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[]{}
            }
        });
});

builder.Services.AddMvcCore();
builder.Services.AddOcelot();
builder.Services.AddSwaggerForOcelot(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerForOcelotUI(opt =>
{
    opt.DownstreamSwaggerHeaders = new[]
    {
        new KeyValuePair<string, string>("Auth-Key", "AuthValue")
    };
});
app.MapControllers();
await app.UseOcelot();

app.Run();
