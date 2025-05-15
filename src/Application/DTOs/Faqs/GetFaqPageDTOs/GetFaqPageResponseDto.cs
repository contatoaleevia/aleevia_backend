namespace Application.DTOs.Faqs.GetFaqPageDTOs;

public class GetFaqPageResponseDto(
    Guid id,
    Guid sourceId,
    string customUrl,
    string? welcomeMessage,
    DateTime createdAt,
    DateTime? updatedAt)
{
    public Guid Id { get; set; } = id;
    public Guid SourceId { get; set; } = sourceId;
    public string CustomUrl { get; set; } = customUrl;
    public string? WelcomeMessage { get; set; } = welcomeMessage;
    public DateTime CreatedAt { get; set; } = createdAt;
    public DateTime? UpdatedAt { get; set; } = updatedAt;
} 