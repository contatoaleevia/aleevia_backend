using Domain.Entities.Faqs;
using Domain.Entities.Identities;

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
    public Guid Id { get; set; } = id;
    public Guid SourceId { get; set; } = sourceId;
    public FaqSourceType SourceType { get; set; } = sourceType;
    public string Question { get; set; } = question;
    public string Answer { get; set; } = answer;
    public string? Link { get; set; } = link;
    public FaqCategoryType FaqCategory { get; set; } = faqCategory;
    public DateTime CreatedAt { get; set; } = createdAt;
    public DateTime? UpdatedAt { get; set; } = updatedAt;
    public DateTime? DeletedAt { get; set; } = deletedAt;
}

public class GetFaqByProfessionalIdResponseDtoList
{
    public List<GetFaqByProfessionalIdResponseDto> Faqs { get; set; } = [];
}