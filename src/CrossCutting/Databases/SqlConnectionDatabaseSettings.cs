using Microsoft.Extensions.Configuration;

namespace CrossCutting.Databases;

public class SqlConnectionDatabaseSettings
{
    public string DefaultConnection { get; set; } = null!;

    public static SqlConnectionDatabaseSettings GetInstance(IConfiguration configuration)
    {
        var connectionSettings = new SqlConnectionDatabaseSettings();

        configuration
            .GetSection("ConnectionStrings")
            .Bind(connectionSettings);

        return connectionSettings;
    }
}