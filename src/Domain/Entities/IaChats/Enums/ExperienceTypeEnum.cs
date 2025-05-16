using System.ComponentModel;

namespace Domain.Entities.IaChats.Enums;

public enum ExperienceTypeEnum : ushort
{
    [Description("Muito boa")]
    VeryGood = 0,
    
    [Description("Boa")]
    Good = 1,
    
    [Description("Regular")]
    Regular = 2,
    
    [Description("Ruim")]
    Bad = 3,
    
    [Description("Muito ruim")]
    VeryBad = 4
} 