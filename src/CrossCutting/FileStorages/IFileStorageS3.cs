namespace CrossCutting.FileStorages;

public interface IFileStorageS3
{
    Task<string> UploadAsync(string bucketName, string fileName, Stream fileStream);
    Task DeleteAsync(string bucketName, string fileName);
}