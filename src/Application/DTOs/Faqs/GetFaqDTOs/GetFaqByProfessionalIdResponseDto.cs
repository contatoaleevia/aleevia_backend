using Domain.Entities.Faqs;
using Domain.Entities.Identities;

namespace Application.DTOs.Faqs.GetFaqDTOs;
public class GetFaqByProfessionalIdResponseDto
{
    public GetFaqByProfessionalIdResponseDto(
        Guid id, 
        Guid sourceId, 
        User? source, 
        FaqSourceType sourceType, 
        string question, 
        string answer,
        FaqCategoryType faqCategory,
        DateTime createdAt, 
        DateTime? updatedAt, 
        DateTime? deletedAt)
    {
        Id = id;
        SourceId = sourceId;
        Source = source;
        SourceType = sourceType;
        Question = question;
        Answer = answer;
        FaqCategory = faqCategory;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DeletedAt = deletedAt;
    }

    public GetFaqByProfessionalIdResponseDto()
    {
    }

    public Guid Id { get; set; }
    public Guid SourceId { get; set; }
    public User? Source { get; set; }
    public FaqSourceType SourceType { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public FaqCategoryType FaqCategory { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}

public class GetFaqByProfessionalIdResponseDtoList
{
    public List<GetFaqByProfessionalIdResponseDto> Faqs { get; set; } = [];
}