namespace Application.DTOs.IaChats.GetIaChatDTOs;

public class GetIaChatResponseDto
{
    public Guid Id { get; set; }
    public Guid? SourceId { get; set; }
    public string? SourceType { get; set; }
    public DateTime CreatedAt { get; set; }
} 