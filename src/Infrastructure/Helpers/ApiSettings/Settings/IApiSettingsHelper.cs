namespace Infrastructure.Helpers.ApiSettings.Settings;

public interface IApiSettingsHelper
{
    public int ExpireHourWithRememberMe { get; set; }
    public int ExpireHourWithoutRememberMe { get; set; }
    public string Issuer { get; set; }
    public string ValidIn { get; set; }
    public string ApiKey { get; set; }
}