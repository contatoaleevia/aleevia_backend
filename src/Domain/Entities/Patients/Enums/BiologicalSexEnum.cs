using System.ComponentModel;

namespace Domain.Entities.Patients.Enums;

public enum BiologicalSexEnum
{
    [Description("Masculino")]
    Male = 0,
    
    [Description("Feminino")]
    Female = 1,
    
    [Description("Outro")]
    Other = 2
} 