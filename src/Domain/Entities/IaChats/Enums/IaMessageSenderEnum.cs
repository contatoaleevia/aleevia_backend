using System.ComponentModel;

namespace Domain.Entities.IaChats.Enums;

public enum IaMessageSenderEnum : ushort
{
    [Description("IA")]
    Ia = 0,
    
    [Description("Client")]
    Client = 1
} 