namespace CrossCutting.MinioFileStorages.Settings;

public interface IMinioSettings
{
    string AccessKey { get; set; }
    string SecretKey { get; set; }
    string Endpoint { get; set; }
    string BucketName { get; set; }
    int Port { get; set; }
    string DomainUrl { get; set; }
}