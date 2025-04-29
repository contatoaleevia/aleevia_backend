using Domain.Entities.Faqs;

namespace Application.DTOs.Faqs.DeleteFaqDTOs;
public class DeleteFaqResponseDto
{
    public DeleteFaqResponseDto(Guid id, Guid sourceId, FaqSourceType sourceType, string question, string answer, FaqCategoryType faqCategory, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt)
    {
        Id = id;
        SourceId = sourceId;
        SourceType = sourceType;
        Question = question;
        Answer = answer;
        FaqCategory = faqCategory;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DeletedAt = deletedAt;
    }

    public Guid Id { get; set; }
    public Guid SourceId { get; set; }
    public FaqSourceType SourceType { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public FaqCategoryType FaqCategory { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}