namespace Application.DTOs.ServiceProviders.GetServiceProviderDTOs;

public class GetServiceProviderByFilterRequestDto
{
    public Guid OfficeId { get; set; }
    public string? Name { get; set; }
    public string? Cnpj { get; set; }
} 