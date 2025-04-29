using Domain.Entities.Faqs;

namespace Application.DTOs.Faqs.CreateFaqDTOs;
public class CreateFaqRequestDto
{
    public CreateFaqRequestDto(Guid sourceId, ushort sourceType, string question, string answer, ushort faqCategory)
    {
        SourceId = sourceId;
        SourceType = sourceType;
        Question = question;
        Answer = answer;
        FaqCategory = faqCategory;
    }

    public Guid SourceId { get; set; }
    public ushort SourceType { get; set; }
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public ushort FaqCategory { get; set; }
}