namespace Application.DTOs.IaChats.CreateIaMessageDTOs;

public class CreateIaMessageResponseDto
{
    public Guid Id { get; set; }
    public Guid IaChatId { get; set; }
    public string SenderType { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
} 