using Amazon.S3;
using System.Net;
using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.Credentials.Internal;
using Amazon.S3.Model;
using CrossCutting.FileStorages.Settings;

namespace CrossCutting.FileStorages;

public class FileStorageS3(IFileStorageSettings settings) : IFileStorageS3
{
   public async Task<string> UploadAsync(string bucketName, string fileName, Stream fileStream)
   {
        var client = BuildClient();
        var request = new PutObjectRequest
        {
            BucketName = bucketName,
            Key = BuildKey(fileName),
            InputStream = fileStream,
            DisablePayloadSigning = true,
            ServerSideEncryptionMethod = ServerSideEncryptionMethod.AES256
        };

        var response = await client.PutObjectAsync(request);

        return response.HttpStatusCode == HttpStatusCode.OK ? $"{settings.DomainUrl}/{request.Key}" : string.Empty;
    }
    
    public async Task DeleteAsync(string bucketName, string fileName)
    {
        var client = BuildClient();
        var request = new DeleteObjectRequest
        {
            BucketName = bucketName,
            Key = BuildKey(fileName)
        };

      var deleteObjectAsync = await client.DeleteObjectAsync(request);
      
      if(deleteObjectAsync.HttpStatusCode != HttpStatusCode.NoContent)
          throw new InvalidOperationException($"Cannot delete file: {fileName}, of bucket: {bucketName}");
    }
    
    private AmazonS3Client BuildClient()
    {
        var credentials = new BasicAWSCredentials(settings.AccessKey, settings.SecretKey);
        return new AmazonS3Client(credentials, new AmazonS3Config
        {
            ServiceURL = settings.ClientUrl,
            ForcePathStyle = true,
            RegionEndpoint = RegionEndpoint.SAEast1
        });
    }
    
    private string BuildKey(string fileName)
    {
        return string.IsNullOrEmpty(settings.BucketPathSharedOffice) ? fileName : $"{settings.BucketPathSharedOffice}/{fileName}";
    }
}