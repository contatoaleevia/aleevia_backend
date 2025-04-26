using System.ComponentModel;

namespace Domain.Entities.Identities.Enums;

public enum UserTypeEnum : ushort
{
    [Description("Gestor")]
    Manager = 0,
    
    [Description("Funcionário")]
    Employee = 1,
    
    [Description("Profissional de saúde")]
    HealthcareProfessional = 2,
    
    [Description("Paciente")]
    Patient = 3
}