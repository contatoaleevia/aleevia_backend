namespace Application.DTOs.Faqs.CreateFaqDTOs;
public class CreateFaqResponseDto
{
    public CreateFaqResponseDto(Guid id, string question, string answer, Guid professionalId)
    {
        Id = id;
        Question = question;
        Answer = answer;
        ProfessionalId = professionalId;
    }
    public Guid Id { get; set; }
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public Guid ProfessionalId { get; set; }
}