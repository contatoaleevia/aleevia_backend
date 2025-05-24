using System.ComponentModel;

namespace Domain.Entities.Identities.Enums;

public enum ManagerTypeEnum : ushort
{
    [Description("Individual")]
    Individual = 0,
    
    [Description("Clínica/Hospital")]
    Office = 1
}