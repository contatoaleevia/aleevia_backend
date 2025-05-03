using CrossCutting.Entities;
using Domain.Entities.Identities;

namespace Domain.Entities.IaChats;

public sealed class IaChat : AggregateRoot
{
    public Guid SourceId { get; private set; }
    public User Source { get; private set; }
    public IaChatSourceType SourceType { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ICollection<IaMessage> Messages { get; private set; } = [];

    private IaChat()
    {
    }

    public IaChat(Guid sourceId, ushort sourceType)
    {
        Id = Guid.NewGuid();
        SourceId = sourceId;
        SourceType = new IaChatSourceType(sourceType);
        CreatedAt = DateTime.UtcNow;
    }
} 