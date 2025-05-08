namespace Application.DTOs.Professionals;

public class CreateProfessionalRequestDto
{
    public string Name { get; set; }
    public string PreferredName { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string CrmNumber { get; set; }
    public string CrmState { get; set; }
    public string Specialty { get; set; }
    public string Cnpj { get; set; }
    public string SocialReason { get; set; }
    public Guid ProfessionId { get; set; }
    public Guid? SpecialtyId { get; set; }
    public Guid? SubSpecialtyId { get; set; }
    public string? Site { get; set; }
    public string? Instagram { get; set; }
    public string? Biography { get; set; }
}