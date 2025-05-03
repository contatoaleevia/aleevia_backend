using CrossCutting.Extensions;
using Domain.Entities.IaChats.Enums;

namespace Domain.Entities.IaChats;

public class IaMessageSenderType
{
    public IaMessageSenderEnum SenderType { get; private set; }
    public string SenderTypeName => SenderType.TryGetDescription();
    
    private IaMessageSenderType()
    {
    }

    public IaMessageSenderType(ushort senderType)
    {
        SenderType = (IaMessageSenderEnum)senderType;
    }
} 