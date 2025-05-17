using Microsoft.Extensions.Configuration;

namespace CrossCutting.MinioFileStorages.Settings;

public class MinioSettings : IMinioSettings
{
    public string AccessKey { get; set; } = null!;
    public string SecretKey { get; set; } = null!;
    public string Endpoint { get; set; } = null!;
    public string BucketName { get; set; } = null!;
    public int Port { get; set; }
    public string DomainUrl { get; set; } = null!;

    public static MinioSettings GetInstance(IConfiguration configuration)
    {
        var minioSettings = new MinioSettings();

        configuration.GetSection("Minio")
            .Bind(minioSettings);

        return minioSettings;
    }
    
}