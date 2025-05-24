using Domain.Entities.Faqs;
using JetBrains.Annotations;

namespace Application.DTOs.Faqs.GetFaqDTOs;

public class GetFaqByProfessionalIdResponseDto(
    Guid id,
    Guid sourceId,
    FaqSourceType sourceType,
    string question,
    string answer,
    string? link,
    FaqCategoryType faqCategory,
    DateTime createdAt,
    DateTime? updatedAt,
    DateTime? deletedAt)
{
    [UsedImplicitly] public Guid Id { get; set; } = id;
    [UsedImplicitly] public Guid SourceId { get; set; } = sourceId;
    [UsedImplicitly] public FaqSourceType SourceType { get; set; } = sourceType;
    [UsedImplicitly] public string Question { get; set; } = question;
    [UsedImplicitly] public string Answer { get; set; } = answer;
    [UsedImplicitly] public string? Link { get; set; } = link;
    [UsedImplicitly] public FaqCategoryType FaqCategory { get; set; } = faqCategory;
    [UsedImplicitly] public DateTime CreatedAt { get; set; } = createdAt;
    [UsedImplicitly] public DateTime? UpdatedAt { get; set; } = updatedAt;
    [UsedImplicitly] public DateTime? DeletedAt { get; set; } = deletedAt;
}

public class GetFaqByProfessionalIdResponseDtoList
{
    public List<GetFaqByProfessionalIdResponseDto> Faqs { get; set; } = [];
}