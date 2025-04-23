using System.ComponentModel;

namespace Domain.Entities.Identities;

public enum UserTypeEnum
{
    [Description("Profissional de saúde")]
    HealthcareProfessional = 1,
    
    [Description("Paciente")]
    Patient = 2
}