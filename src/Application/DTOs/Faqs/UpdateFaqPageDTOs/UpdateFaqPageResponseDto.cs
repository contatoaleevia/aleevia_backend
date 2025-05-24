using JetBrains.Annotations;

namespace Application.DTOs.Faqs.UpdateFaqPageDTOs;

[UsedImplicitly]
public record UpdateFaqPageResponseDto(
    Guid Id,
    Guid SourceId,
    string CustomUrl,
    string? WelcomeMessage,
    DateTime CreatedAt,
    DateTime? UpdatedAt
); 