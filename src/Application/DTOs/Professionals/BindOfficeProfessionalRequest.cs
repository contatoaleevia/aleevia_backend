namespace Application.DTOs.Professionals;

public class BindOfficeProfessionalRequest
{
    public PreRegisterProfessionalRequest Professional { get; set; }
    public Guid OfficeId { get; set; }
    public bool Active { get; set; }
    public bool IsPublic { get; set; }
}