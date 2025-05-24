using CrossCutting.Extensions;
using JetBrains.Annotations;

namespace Domain.Entities.Faqs;
public class FaqCategoryType
{
    public FaqCategoryEnum CategoryType { get; set; }
    public string CategoryTypeName => CategoryType.TryGetDescription();

    [UsedImplicitly]
    private FaqCategoryType()
    {
    }

    public FaqCategoryType(ushort categoryType)
    {
        CategoryType = (FaqCategoryEnum)categoryType;
    }

    public FaqCategoryType(string description)
    {
        var result = EnumExtensions.GetEnumFromDescription<FaqCategoryEnum>(description);
        if (result == null)
            throw new ArgumentException($"Descrição inválida: {description}");

        CategoryType = result.Value;
    }
}