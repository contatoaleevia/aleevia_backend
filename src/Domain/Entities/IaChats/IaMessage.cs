using CrossCutting.Entities;

namespace Domain.Entities.IaChats;

public sealed class IaMessage : AggregateRoot
{
    public Guid IaChatId { get; private set; }
    public IaChat IaChat { get; private set; }
    public IaMessageSenderType SenderType { get; private set; }
    public string Message { get; private set; }
    public string Content { get; private set; }
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