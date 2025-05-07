using CrossCutting.Entities;

namespace Domain.Entities.Faqs;
public sealed class FaqPage : AggregateRoot
{
    public Guid SourceId { get; private set; }
    public string CustomUrl { get; private set; }
    public string? WelcomeMessage { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private FaqPage()
    {
    }

    public FaqPage(
        Guid sourceId,
        string customUrl,
        string? welcomeMessage,
        DateTime createdAt)
    {
        Id = Guid.NewGuid();
        SourceId = sourceId;
        CustomUrl = customUrl.ToLower().Trim();
        WelcomeMessage = welcomeMessage;
        CreatedAt = createdAt;
    }

    public void Update(string? welcomeMessage)
    {
        WelcomeMessage = welcomeMessage;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateCustomUrl(string customUrl)
    {
        CustomUrl = customUrl.ToLower().Trim();
        UpdatedAt = DateTime.UtcNow;
    }
} 