using System.ComponentModel;

namespace Domain.Entities.IaChats.Enums;

public enum IaChatSourceEnum : ushort
{
    [Description("Patient")]
    Patient = 0,
    
    [Description("Professional")]
    Professional = 1,
    
    [Description("Lead")]
    Lead = 2
} 