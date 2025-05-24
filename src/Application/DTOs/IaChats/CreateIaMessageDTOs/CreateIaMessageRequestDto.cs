using System.Text.Json;
using JetBrains.Annotations;

namespace Application.DTOs.IaChats.CreateIaMessageDTOs;

public class CreateIaMessageRequestDto
{
    [UsedImplicitly] public required ushort SenderType { get; set; }
    public required string Message { get; set; }
    public required JsonDocument Content { get; set; }
} 