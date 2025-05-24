using CrossCutting.Extensions;
using Domain.Entities.IaChats.Enums;
using JetBrains.Annotations;

namespace Domain.Entities.IaChats;

public class IaChatSourceType
{
    public IaChatSourceEnum SourceType { get; private set; }
    public string SourceTypeName => SourceType.TryGetDescription();
    
    [UsedImplicitly]
    private IaChatSourceType()
    {
    }

    public IaChatSourceType(ushort sourceType)
    {
        SourceType = (IaChatSourceEnum)sourceType;
    }
} 