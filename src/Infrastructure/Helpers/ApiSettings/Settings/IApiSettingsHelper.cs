namespace Infrastructure.Helpers.ApiSettings.Settings;

public interface IApiSettingsHelper
{
    public int ExpireHour { get; set; }
    public string Issuer { get; set; }
    public string ValidIn { get; set; }
    public string ApiKey { get; set; }
}