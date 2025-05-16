using Domain.Entities.Offices;

namespace Application.DTOs.Offices.BindOfficeProfessionalDTOs;
 
public class BindOfficeProfessionalResponse(OfficesProfessional officeProfessional)
{
    public Guid Id { get; private set; } = officeProfessional.Id;
    public Guid ProfessionalId { get; private set; } = officeProfessional.ProfessionalId;
    public string? Name { get; private set; } = officeProfessional.GetProfessionalName();
    public string? PreferredName { get; private set; } = officeProfessional.GetProfessionalPreferredName();
    public string? Email { get; private set; } = officeProfessional.GetProfessionalEmail();
    public string Cpf { get; private set; } = officeProfessional.GetProfessionalCpfFormatted();
    public string? Cnpj { get; private set; } = officeProfessional.GetProfessionalCnpjFormatted();
} 