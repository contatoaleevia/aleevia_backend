using CrossCutting.FileStorages;
using CrossCutting.MinioFileStorages;
using Domain.Exceptions.Offices;

namespace Application.Services.Offices;

public class OfficeFileSender(IMinioService minioService) : IOfficeFileSender
{
    private const string BucketName = "aleevia";

    public async Task<string> UploadLogoAsync(string fileName, Stream fileStream)
    {
        try
        {
            var mediaUrl = await minioService.UploadAsync(BucketName, fileName, fileStream);
            if (string.IsNullOrEmpty(mediaUrl))
                throw new SendLogoException("Url do arquivo não pode ser nula ou vazia.");

            return mediaUrl;
        }
        catch (Exception e)
        {
            throw new SendLogoException(e.Message);
        }
    }

    public async Task DeleteLogoAsync(string fileName)
    {
        try
        {
           await minioService.DeleteAsync(BucketName, fileName);

        }
        catch (Exception)
        {
            throw new DeleteLogoException();
        }
    }
}