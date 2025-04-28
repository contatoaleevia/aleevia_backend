namespace Application.DTOs.Faqs.GetFaqDTOs;
public class GetFaqByProfessionalIdRequestDto
{
    public GetFaqByProfessionalIdRequestDto(Guid professionalId)
    {
        ProfessionalId = professionalId;
    }
    public Guid ProfessionalId { get; private set; }
}