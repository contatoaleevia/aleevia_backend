using System.ComponentModel;

namespace Domain.Entities.IaChats.Enums;

public enum IaChatSourceEnum : ushort
{
    [Description("Gestor")]
    Manager = 0,
    
    [Description("Funcionário")]
    Employee = 1,
    
    [Description("Profissional de saúde")]
    HealthcareProfessional = 2,
    
    [Description("Paciente")]
    Patient = 3,

    [Description("Lead")]
    Lead = 4
} 