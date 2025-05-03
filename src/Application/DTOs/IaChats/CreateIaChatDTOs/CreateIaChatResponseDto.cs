namespace Application.DTOs.IaChats.CreateIaChatDTOs;

public class CreateIaChatResponseDto
{
    public Guid Id { get; set; }
    public Guid SourceId { get; set; }
    public string SourceType { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
} 