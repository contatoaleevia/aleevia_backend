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

    public FaqSourceType(string description)
    {
        var result = EnumExtensions.GetEnumFromDescription<FaqSourceEnum>(description);
        if (result == null)
            throw new ArgumentException($"Descrição inválida: {description}");

        SourceType = result.Value;
    }
}