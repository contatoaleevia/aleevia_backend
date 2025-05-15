using System.Text.Json;

namespace Application.DTOs.IaChats.CreateIaMessageDTOs;

public class CreateIaMessageRequestDto
{
    public required ushort SenderType { get; set; }
    public required string Message { get; set; }
    public required JsonDocument Content { get; set; }
} 