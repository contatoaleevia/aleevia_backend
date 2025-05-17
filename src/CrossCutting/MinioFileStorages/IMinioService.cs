namespace CrossCutting.MinioFileStorages;

public interface IMinioService
{
    Task<string> UploadAsync(string bucketName, string fileName, Stream fileStream);
    Task DeleteAsync(string bucketName, string fileName);
}