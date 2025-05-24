using CrossCutting.Extensions;
using JetBrains.Annotations;

namespace Domain.Entities.Faqs;
public class FaqSourceType
{
    public FaqSourceEnum SourceType { get; set; }
    public string SourceTypeName => SourceType.TryGetDescription();

    [UsedImplicitly]
    private FaqSourceType()
    {
    }

    public FaqSourceType(ushort sourceType)
    {
        SourceType = (FaqSourceEnum)sourceType;
    }
}