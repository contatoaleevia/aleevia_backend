using CrossCutting.Extensions;

namespace Domain.Entities.Faqs;
public class FaqCategoryType
{
    public FaqCategoryEnum CategoryType { get; set; }
    public string CategoryTypeName => CategoryType.TryGetDescription();

    private FaqCategoryType()
    {
    }

    public FaqCategoryType(ushort categoryType)
    {
        CategoryType = (FaqCategoryEnum)categoryType;
    }
}