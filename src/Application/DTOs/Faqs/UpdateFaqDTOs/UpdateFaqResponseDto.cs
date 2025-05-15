using Domain.Entities.Faqs;

namespace Application.DTOs.Faqs.UpdateFaqDTOs;

public record UpdateFaqResponseDto
{
    public required UpdateFaqData Faq { get; init; }

    public static UpdateFaqResponseDto FromFaq(Faq faq)
    {
        ArgumentNullException.ThrowIfNull(faq);

        return new UpdateFaqResponseDto
        {
            Faq = new UpdateFaqData
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
                UpdatedAt = faq.UpdatedAt
            }
        };
    }
}

public record UpdateFaqData
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
}