using Domain.Entities.Faqs;

namespace Application.DTOs.Faqs.CreateFaqDTOs;
public class CreateFaqRequestDto(Guid sourceId, ushort sourceType, string question, string answer, string? link, ushort faqCategory)
{
    public Guid SourceId { get; set; } = sourceId;
    public ushort SourceType { get; set; } = sourceType;
    public string Question { get; set; } = question;
    public string Answer { get; set; } = answer;
    public string? Link { get; set; } = link;
    public ushort FaqCategory { get; set; } = faqCategory;
}