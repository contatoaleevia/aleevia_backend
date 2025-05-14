using Microsoft.Extensions.Configuration;

namespace CrossCutting.FileStorages.Settings;

public class FileStorageSettings : IFileStorageSettings
{
    public string AccessKey { get; set; } = null!;
    public string SecretKey { get; set; } = null!;
    public string ClientUrl { get; set; } = null!;
    public string DomainUrl { get; set; } = null!;
    public string BucketPathName { get; set; } = null!;

    public static FileStorageSettings GetInstance(IConfiguration configuration)
    {
        var fileStorageSettings = new FileStorageSettings();

        configuration.GetSection("FileStorage")
            .Bind(fileStorageSettings);

        return fileStorageSettings;
    }
}