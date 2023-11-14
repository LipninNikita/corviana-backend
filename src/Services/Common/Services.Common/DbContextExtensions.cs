using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using System.Data.SqlClient;

namespace Services.Common
{
    public static class DbContextExtensions
    {
        public static IServiceProvider MigrateDbContext<TContext>(this IServiceProvider services) where TContext : DbContext
        {
            using var scope = services.CreateScope();
            var scopeServices = scope.ServiceProvider;
            var logger = scopeServices.GetRequiredService<ILogger<TContext>>();
            var context = scopeServices.GetService<TContext>();

            try
            {
                logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TContext).Name);

                var retries = 10;
                var retry = Policy.Handle<SqlException>()
                    .WaitAndRetry(
                        retryCount: retries,
                        sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                        onRetry: (exception, timeSpan, retry, ctx) =>
                        {
                            logger.LogWarning(exception, "[{prefix}] Error migrating database (attempt {retry} of {retries})", nameof(TContext), retry, retries);
                        });

                context.Database.Migrate();

                logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(TContext).Name);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TContext).Name);
            }

            return services;
        }
    }
}
