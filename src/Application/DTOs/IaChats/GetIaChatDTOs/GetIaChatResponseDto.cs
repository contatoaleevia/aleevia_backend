namespace Application.DTOs.IaChats.GetIaChatDTOs;

public class GetIaChatResponseDto
{
    public Guid Id { get; set; }
    public Guid SourceId { get; set; }
    public string SourceName { get; set; } = string.Empty;
    public string SourceType { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
} 