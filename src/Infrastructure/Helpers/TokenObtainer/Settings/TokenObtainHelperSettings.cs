using Microsoft.Extensions.Configuration;

namespace Infrastructure.Helpers.TokenObtainer.Settings;

public class TokenObtainHelperSettings : ITokenObtainHelperSettings
{
    public string Secret { get; set; } = null!;

    public static ITokenObtainHelperSettings GetInstance(IConfiguration configuration)
    {   
        var settings = new TokenObtainHelperSettings();
            
        configuration.GetSection("Identity")
            .GetSection("TokenObtainHelperSettings")
            .Bind(settings);

        return settings;
    }
}