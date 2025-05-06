namespace Application.DTOs.Professionals;
public class BindProfessionalOfficeRequestDto
{
    public string Cpf { get; set; }
    public Guid OfficeId { get; set; }
    public bool Active { get; set; }
}