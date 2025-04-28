namespace Application.DTOs.Faqs.UpdateFaqDTOs;
public class UpdateFaqRequestDto
{
    public UpdateFaqRequestDto(Guid id, Guid sourceId, string question, string answer, ushort faqCategory)
    {
        Id = id;
        SourceId = sourceId;
        Question = question;
        Answer = answer;
        FaqCategory = faqCategory;
    }
    public Guid Id { get; set; }
    public Guid SourceId { get; set; }
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public ushort FaqCategory { get; set; }
}