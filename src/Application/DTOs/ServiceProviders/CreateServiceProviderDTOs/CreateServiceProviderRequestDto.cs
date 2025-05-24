using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.ServiceProviders.CreateServiceProviderDTOs;

public class CreateServiceProviderRequestDto
{
    [Required(ErrorMessage = "CNPJ e obrigatório")]
    public required string Cnpj { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Razão social é obrigatória")]
    public required string CorporateName { get; set; }

    [Required(ErrorMessage = "Id da unidade é obrigatório")]
    public required Guid OfficeId { get; set; }
} 