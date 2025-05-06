using System.ComponentModel;

namespace Domain.Entities.Patients.Enums;

public enum GenderEnum
{
    [Description("Homem Cis")]
    ManCis = 0,
    
    [Description("Mulher Cis")]
    WomanCis = 1,
    
    [Description("Mulher Trans")]
    WomanTrans = 2,
    
    [Description("Homem Trans")]
    ManTrans = 3,
    
    [Description("Não Binário")]
    NonBinary = 4,
    
    [Description("Prefiro não dizer")]
    PreferNotToSay = 5,
    
    [Description("Outros")]
    Other = 6
} 