using System.ComponentModel;

namespace Domain.Entities.Identities;

public enum UserTypeEnum : ushort
{
    [Description("Profissional de saúde")]
    HealthcareProfessional = 0,
    
    [Description("Paciente")]
    Patient = 1
}