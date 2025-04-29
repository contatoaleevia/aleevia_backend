using CrossCutting.Entities;
using Domain.Entities.Identities;

namespace Domain.Entities.Faqs;
public sealed class Faq : AggregateRoot
{
    public Guid SourceId { get; set; }
    public User? Source { get; set; }
    public FaqSourceType SourceType { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public FaqCategoryType FaqCategory { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    private Faq()
    {
    }

    public Faq(Guid id, Guid sourceId, ushort sourceType, string question, string answer, ushort faqCategory, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt)
    {
        Id = id;
        SourceId = sourceId;
        SourceType = new FaqSourceType(sourceType);
        Question = question;
        Answer = answer;
        FaqCategory = new FaqCategoryType(faqCategory);
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DeletedAt = deletedAt;
    }
}