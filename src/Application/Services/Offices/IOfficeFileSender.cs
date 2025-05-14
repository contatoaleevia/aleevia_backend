namespace Application.Services.Offices;

public interface IOfficeFileSender
{
    Task<string> UploadLogoAsync(string fileName, Stream fileStream);
    Task DeleteLogoAsync(string fileName);
}