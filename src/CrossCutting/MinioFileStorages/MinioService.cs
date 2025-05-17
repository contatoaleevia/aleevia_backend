using CrossCutting.MinioFileStorages.Settings;
using Minio;
using Minio.DataModel.Args;

namespace CrossCutting.MinioFileStorages;

public class MinioService(IMinioSettings settings, IMinioClient client) : IMinioService
{
    public async Task<string> UploadAsync(string bucketName, string fileName, Stream fileStream)
    {
        var found = await client.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucketName)).ConfigureAwait(false);
        if (!found)
        {
            await client.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucketName)).ConfigureAwait(false);
        }

        // Upload the file
        var response = await client.PutObjectAsync(new PutObjectArgs()
            .WithBucket(bucketName)
            .WithObject(fileName)
            .WithStreamData(fileStream)
            .WithObjectSize(fileStream.Length)
            .WithContentType("application/octet-stream")
        ).ConfigureAwait(false);

        Console.Write(response.ObjectName);
        return $"{settings.DomainUrl}/{fileName}";
    }

    public async Task DeleteAsync(string bucketName, string fileName)
    {
        try 
        {
            await client.RemoveObjectAsync(new RemoveObjectArgs()
                .WithBucket(bucketName)
                .WithObject(fileName)
            ).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Cannot delete file: {fileName}, of bucket: {bucketName}", ex);
        }
    }
}
