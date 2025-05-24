using JetBrains.Annotations;

namespace Application.DTOs.Faqs.CreateFaqPageDTOs;

[UsedImplicitly]
public record CreateFaqPageResponseDto(
    Guid Id,
    Guid SourceId,
    string CustomUrl,
    string? WelcomeMessage,
    string SourceType,
    DateTime CreatedAt
); 