using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Services.Common
{
    public static class CommonExtensions
    {
        public static WebApplicationBuilder AddServiceDefaults(this WebApplicationBuilder builder)
        {
            builder.AddDefaultAuthentication(builder.Configuration);
            //builder.Services.AddAuthorization();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddDefaultOpenApi();

            builder.Services.AddMvcCore(opt =>
            {
                opt.EnableEndpointRouting = false;
            }).AddAuthorization();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddCors();

            return builder;
        }
        public static WebApplication UseServiceDefaults(this WebApplication app)
        {
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseDefaultOpenApi(app.Configuration);

            app.MapControllers().RequireAuthorization();

            app.UseCors(x => { x.AllowAnyOrigin(); x.AllowAnyHeader(); x.AllowAnyMethod(); });

            app.UseMvc().UseMvcWithDefaultRoute();

            return app;
        }

        public static IApplicationBuilder UseDefaultOpenApi(this WebApplication app, IConfiguration configuration)
        {
            var openApiSection = configuration.GetSection("OpenApi");

            app.UseSwagger();
            app.UseSwaggerUI(setup =>
            {
                var endpointSection = openApiSection.GetRequiredSection("Endpoint");

                var swaggerUrl = "/swagger/v1/swagger.json";

                setup.SwaggerEndpoint(swaggerUrl, endpointSection.GetValue<string>("Name"));
            });

            return app;
        }
        public static IServiceCollection AddDefaultOpenApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
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

            return services;
        }
        public static WebApplicationBuilder AddDefaultAuthentication(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Auth:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Auth:SigningKey"])),
                    ClockSkew = TimeSpan.Zero,
                };
            });

            return builder;
        }
    }
}