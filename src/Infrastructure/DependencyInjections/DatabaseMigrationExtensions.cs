using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.DependencyInjections;

public static class DatabaseMigrationExtensions
{
    public static void MigrateDatabase<TContext>(this IApplicationBuilder app) 
        where TContext : DbContext
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<TContext>>();
        var context = services.GetRequiredService<TContext>();

        try
        {
            logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TContext).Name);
            context.Database.Migrate();
            logger.LogInformation("Database migration completed");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while migrating the database for context {DbContextName}", typeof(TContext).Name);
        }
    }
}