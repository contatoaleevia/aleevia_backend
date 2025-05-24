using CrossCutting.Extensions;
using Domain.Entities.IaChats.Enums;
using JetBrains.Annotations;

namespace Domain.Entities.IaChats;

public class IaMessageSenderType
{
    public IaMessageSenderEnum SenderType { get; private set; }
    public string SenderTypeName => SenderType.TryGetDescription();
    
    [UsedImplicitly]
    private IaMessageSenderType()
    {
    }

    public IaMessageSenderType(ushort senderType)
    {
        SenderType = (IaMessageSenderEnum)senderType;
    }
} 