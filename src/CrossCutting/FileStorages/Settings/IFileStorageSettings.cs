namespace CrossCutting.FileStorages.Settings;

public interface IFileStorageSettings
{
    string AccessKey { get; set; }
    string SecretKey { get; set; }
    string ClientUrl { get; set; }
    string DomainUrl { get; set; }
    string BucketPathName { get; set; }
}