using CrossCutting.FileStorages;
using Domain.Exceptions.Offices;

namespace Application.Services.Offices;

public class OfficeFileSender(IFileStorageS3 fileStorageS3) : IOfficeFileSender
{
    private const string BucketName = "office";

    public async Task<string> UploadLogoAsync(string fileName, Stream fileStream)
    {
        try
        {
            var mediaUrl = await fileStorageS3.UploadAsync(BucketName, fileName, fileStream);
            if (string.IsNullOrEmpty(mediaUrl))
                throw new SendLogoException();

            return mediaUrl;
        }
        catch (Exception)
        {
            throw new SendLogoException();
        }
    }

    public async Task DeleteLogoAsync(string fileName)
    {
        try
        {
           await fileStorageS3.DeleteAsync(BucketName, fileName);

        }
        catch (Exception)
        {
            throw new DeleteLogoException();
        }
    }
}