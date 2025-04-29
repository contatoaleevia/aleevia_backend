using CrossCutting.Extensions;

namespace Domain.Entities.Faqs;
public class FaqSourceType
{
    public FaqSourceEnum SourceType { get; set; }
    public string SourceTypeName => SourceType.TryGetDescription();

    private FaqSourceType()
    {
    }

    public FaqSourceType(ushort sourceType)
    {
        SourceType = (FaqSourceEnum)sourceType;
    }
}