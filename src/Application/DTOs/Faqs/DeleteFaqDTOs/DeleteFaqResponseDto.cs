using Domain.Entities.Faqs;

namespace Application.DTOs.Faqs.DeleteFaqDTOs;

public record DeleteFaqResponseDto
{
    public required DeleteFaqData Faq { get; init; }

    public static DeleteFaqResponseDto FromFaq(Faq faq)
    {
        ArgumentNullException.ThrowIfNull(faq);

        return new DeleteFaqResponseDto
        {
            Faq = new DeleteFaqData
            {
                Id = faq.Id,
                SourceId = faq.SourceId,
                SourceType = faq.SourceType,
                Question = faq.Question,
                Answer = faq.Answer,
                Link = faq.Link,
                FaqCategory = faq.FaqCategory,
                IsActive = faq.IsActive,
                CreatedAt = faq.CreatedAt,
                UpdatedAt = faq.UpdatedAt,
                DeletedAt = faq.DeletedAt
            }
        };
    }
}

public record DeleteFaqData
{
    public required Guid Id { get; init; }
    public required Guid SourceId { get; init; }
    public required FaqSourceType SourceType { get; init; }
    public required string Question { get; init; }
    public required string Answer { get; init; }
    public string? Link { get; init; }
    public required FaqCategoryType FaqCategory { get; init; }
    public required bool IsActive { get; init; }
    public required DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
    public DateTime? DeletedAt { get; init; }
}