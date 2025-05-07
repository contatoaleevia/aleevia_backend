namespace Application.DTOs.Professionals;

public class CreateProfessionalRequestDto
{
    public Guid ManagerId { get; set; }
    public string Cpf { get; set; }
}