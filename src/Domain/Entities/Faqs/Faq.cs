using CrossCutting.Entities;
using Domain.Entities.Identities;

namespace Domain.Entities.Faqs;
public sealed class Faq : AggregateRoot
{
    public Guid SourceId { get; private set; }
    public User? Source { get; private set; }
    public FaqSourceType SourceType { get; private set; } = null!;
    public string Question { get; private set; } = string.Empty;
    public string Answer { get; private set; } = string.Empty;
    public string? Link { get; private set; }
    public FaqCategoryType FaqCategory { get; private set; } = null!;
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    private Faq()
    {
    }

    public Faq(Guid sourceId, ushort sourceType, string question, string answer, string? link, ushort faqCategory, DateTime createdAt, DateTime? updatedAt = null, DateTime? deletedAt = null)
    {
        SourceId = sourceId;
        SourceType = new FaqSourceType(sourceType);
        Question = question;
        Answer = answer;
        Link = link;
        FaqCategory = new FaqCategoryType(faqCategory);
        IsActive = true;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DeletedAt = deletedAt;
    }

    public void Update(string? question = null, string? answer = null, string? link = null, ushort? faqCategory = null)
    {
        Question = question ?? Question;
        Answer = answer ?? Answer;
        Link = link ?? Link;
        if (faqCategory.HasValue)
            FaqCategory = new FaqCategoryType(faqCategory.Value);
        UpdatedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsActive = false;
        DeletedAt = DateTime.UtcNow;
    }

    public void SetSourceInfo(Guid sourceId, ushort sourceType)
    {
        SourceId = sourceId;
        SourceType = new FaqSourceType(sourceType);
    }
}