using CrossCutting.Entities;
using JetBrains.Annotations;

namespace Domain.Entities.IaChats;

public sealed class IaChat : AggregateRoot
{
    public Guid? SourceId { get; private set; }
    public IaChatSourceType SourceType { get; private set; } = null!;
    public Guid? HashSourceId { get; private set; }
    public ushort? HashSourceType { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ICollection<IaMessage> Messages { get; private set; } = [];

    [UsedImplicitly]
    private IaChat()
    {
    }

    public IaChat(Guid? sourceId, ushort sourceType, Guid? hashSourceId = null, ushort? hashSourceType = null)
    {
        Id = Guid.NewGuid();
        SourceId = sourceId;
        SourceType = new IaChatSourceType(sourceType);
        HashSourceId = hashSourceId;
        HashSourceType = hashSourceType;
        CreatedAt = DateTime.UtcNow;
    }
} 