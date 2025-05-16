using System.ComponentModel;

namespace Domain.Entities.IaChats.Enums;

public enum ProblemSolvedTypeEnum : ushort
{
    [Description("Sim")]
    Yes = 0,
    
    [Description("Parcialmente")]
    Partially = 1,
    
    [Description("Não")]
    No = 2
} 