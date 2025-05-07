namespace Application.DTOs.Offices.BindOfficeAddressDTOs;
public class BindOfficeAddressRequest
{
    public Guid OfficeId { get; set; }
    public Guid? AddressId { get; set; }
}