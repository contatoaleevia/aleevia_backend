namespace Application.DTOs.Faqs.UpdateFaqDTOs;
public class UpdateFaqRequestDto(Guid id, Guid sourceId, string question, string answer, ushort faqCategory)
{
    public Guid Id { get; set; } = id;
    public Guid SourceId { get; set; } = sourceId;
    public string Question { get; set; } = question;
    public string Answer { get; set; } = answer;
    public ushort FaqCategory { get; set; } = faqCategory;
}