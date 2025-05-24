using JetBrains.Annotations;

namespace Application.DTOs.Faqs.GetFaqPageDTOs;

public class GetFaqPageResponseDto(
    Guid id,
    Guid sourceId,
    string customUrl,
    string? welcomeMessage,
    DateTime createdAt,
    DateTime? updatedAt)
{
    [UsedImplicitly] public Guid Id { get; set; } = id;
    [UsedImplicitly] public Guid SourceId { get; set; } = sourceId;
    [UsedImplicitly] public string CustomUrl { get; set; } = customUrl;
    [UsedImplicitly] public string? WelcomeMessage { get; set; } = welcomeMessage;
    [UsedImplicitly] public DateTime CreatedAt { get; set; } = createdAt;
    [UsedImplicitly] public DateTime? UpdatedAt { get; set; } = updatedAt;
} 