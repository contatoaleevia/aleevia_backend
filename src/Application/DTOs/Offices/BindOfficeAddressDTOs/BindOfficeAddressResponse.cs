namespace Application.DTOs.Offices.BindOfficeAddressDTOs;
 
public record BindOfficeAddressResponse(Guid Id)
{
    public Guid Id { get; set; } = Id;
} 