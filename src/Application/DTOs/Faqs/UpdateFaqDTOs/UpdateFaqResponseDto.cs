using Domain.Entities.Faqs;

namespace Application.DTOs.Faqs.UpdateFaqDTOs;
public class UpdateFaqResponseDto
{
    public UpdateFaqResponseDto(Guid id, Guid sourceId, FaqSourceType sourceType, string question, string answer, FaqCategoryType faqCategory, DateTime createdAt, DateTime? updateAt)
    {
        Id = id;
        SourceId = sourceId;
        SourceType = sourceType;
        Question = question;
        Answer = answer;
        FaqCategory = faqCategory;
        CreatedAt = createdAt;
        UpdatedAt = updateAt;
    }
    public Guid Id { get; set; }
    public Guid SourceId { get; set; }
    public FaqSourceType SourceType { get; set; }
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public FaqCategoryType FaqCategory { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}