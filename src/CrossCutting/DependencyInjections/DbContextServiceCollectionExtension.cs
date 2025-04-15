using CrossCutting.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjections;

public static class DbContextServiceCollectionExtension
{
    public static void RegisterPostgresSql<T>(this IServiceCollection services, IConfiguration configuration)
        where T : DbContext
    {
        var connection = SqlConnectionDatabaseSettings.GetInstance(configuration);
        services.AddDbContext<T>(options =>
            options.UseNpgsql(connection.DefaultConnection));
    }
}