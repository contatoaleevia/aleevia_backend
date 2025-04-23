using Microsoft.Extensions.Configuration;

namespace Infrastructure.Helpers.ApiSettings.Settings;

public class ApiSettingsHelper : IApiSettingsHelper
{
    public int ExpireHour { get; set; }
    public string Issuer { get; set; } = null!;
    public string ValidIn { get; set; } = null!;

    public static IApiSettingsHelper GetInstance(IConfiguration configuration)
    {
        var settings = new ApiSettingsHelper();
            
        configuration
            .GetSection("ApiSettings")
            .Bind(settings);

        return settings;
    }
}