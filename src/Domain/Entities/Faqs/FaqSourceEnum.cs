using System.ComponentModel;

namespace Domain.Entities.Faqs;
public enum FaqSourceEnum : ushort
{
    [Description("Profissional")]
    Professional = 0,
    [Description("Office")]
    Office = 1
}