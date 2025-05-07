using Domain.Entities.Professionals;
using Domain.Entities.ValueObjects;

namespace Application.DTOs.Professionals;
public class BindProfessionalOfficeResponseDto
{
    public Guid UserId { get; set; }
    public ProfessionalRegisterStatus RegisterStatus { get; set; }
    public Guid OfficeId { get; set; }
    public bool Active { get; set; }
    public Document Cpf { get; set; }
    public Url? Website { get; set; }
    public Url? Instagram { get; set; }
    public Url? Linkedin { get; set; }
    public Url? Doctoralia { get; set; }
    public Url? Biography { get; set; }
    public Url? PictureUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}