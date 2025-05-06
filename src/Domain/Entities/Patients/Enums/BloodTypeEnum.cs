using System.ComponentModel;

namespace Domain.Entities.Patients.Enums;

public enum BloodTypeEnum
{
    [Description("A+")]
    APositive = 0,
    
    [Description("A-")]
    ANegative = 1,
    
    [Description("B+")]
    BPositive = 2,
    
    [Description("B-")]
    BNegative = 3,
    
    [Description("AB+")]
    ABPositive = 4,
    
    [Description("AB-")]
    ABNegative = 5,
    
    [Description("O+")]
    OPositive = 6,
    
    [Description("O-")]
    ONegative = 7,
    
    [Description("Desconhecido")]
    Unknown = 8
} 