namespace Application.DTOs.Professionals;
public class PreCreateProfessionalRequestDto
{
    public Guid OfficeId { get; set; }
    public string Cpf { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Link { get; set; }
}