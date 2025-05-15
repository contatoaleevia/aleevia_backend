using Domain.Entities.Faqs;

namespace Application.DTOs.Faqs.CreateFaqDTOs;

public record CreateFaqResponseDto
{
    public required CreateFaqData Faq { get; init; }

    public static CreateFaqResponseDto FromFaq(Faq faq)
    {
        ArgumentNullException.ThrowIfNull(faq);

        return new CreateFaqResponseDto
        {
            Faq = new CreateFaqData
            {
                Id = faq.Id,
                SourceId = faq.SourceId,
                SourceType = faq.SourceType,
                Question = faq.Question,
                Answer = faq.Answer,
                Link = faq.Link,
                FaqCategory = faq.FaqCategory,
                IsActive = faq.IsActive,
                CreatedAt = faq.CreatedAt
            }
        };
    }
}

public record CreateFaqData
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
}