using System.Text.Json;
namespace Application.DTOs.IaChats.GetIaMessageDTOs;

public class GetIaMessageResponseDto
{
    public Guid Id { get; set; }
    public Guid IaChatId { get; set; }
    public string SenderType { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public JsonDocument Content { get; set; } = JsonDocument.Parse("{}");
    public DateTime CreatedAt { get; set; }
} 