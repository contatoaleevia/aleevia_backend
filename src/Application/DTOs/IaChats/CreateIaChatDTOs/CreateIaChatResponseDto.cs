using System.Text.Json;
namespace Application.DTOs.IaChats.CreateIaChatDTOs;


public class CreateIaChatResponseDto
{
    public Guid Id { get; set; }
    public Guid? SourceId { get; set; }
    public string? SourceType { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Message { get; set; }
    public JsonDocument? Content { get; set; }
} 