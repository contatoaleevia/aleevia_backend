using System.Text.Json;

namespace Application.DTOs.IaChats.CreateIaMessageDTOs;

public class CreateIaMessageResponseDto
{
    public Guid Id { get; set; }
    public Guid IaChatId { get; set; }
    public string Message { get; set; } = string.Empty;
    public JsonDocument Content { get; set; } = JsonDocument.Parse("{}");
    public DateTime CreatedAt { get; set; }
} 