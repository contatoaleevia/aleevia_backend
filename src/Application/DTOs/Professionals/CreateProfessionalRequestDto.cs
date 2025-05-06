namespace Application.DTOs.Professionals;
public class CreateProfessionalRequestDto
{
    public Guid UserId { get; set; }
    public ushort Status { get; set; }
    public Guid OfficeId { get; set; }
    public string Cnpj { get; set; }
    public Guid Office { get; set; }
    public Guid Profession { get; set; }
    public bool Active { get; set; }
}