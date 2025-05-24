using System.ComponentModel;

namespace Domain.Entities.Faqs;

public enum FaqCategoryEnum
{
    [Description("Orientações ao cliente")]
    ClientOrientations = 0,
    [Description("Sobre o profissional")]
    AboutProfessional = 1,
    [Description("Sobre a clínica")]
    AboutClinic = 2
}