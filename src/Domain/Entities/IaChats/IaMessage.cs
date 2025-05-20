using CrossCutting.Entities;

namespace Domain.Entities.IaChats;

public sealed class IaMessage : AggregateRoot
{
    public Guid IaChatId { get; private set; }
    public IaChat IaChat { get; private set; } = null!;
    public IaMessageSenderType SenderType { get; private set; } = null!;
    public string Message { get; private set; } = string.Empty;
    public string Content { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }

    private IaMessage()
    {
    }

    public IaMessage(Guid iaChatId, ushort senderType, string message, string content)
    {
        Id = Guid.NewGuid();
        IaChatId = iaChatId;
        SenderType = new IaMessageSenderType(senderType);
        Message = message;
        Content = content;
        CreatedAt = DateTime.UtcNow;
    }
} 