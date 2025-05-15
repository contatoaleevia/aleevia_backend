namespace Application.DTOs.Faqs.UpdateFaqPageDTOs;

public record UpdateFaqPageResponseDto(
    Guid Id,
    Guid SourceId,
    string CustomUrl,
    string? WelcomeMessage,
    DateTime CreatedAt,
    DateTime? UpdatedAt
); 