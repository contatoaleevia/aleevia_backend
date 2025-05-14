using Domain.Entities.Faqs;

namespace Application.DTOs.Faqs.CreateFaqPageDTOs;

public record CreateFaqPageResponseDto(
    Guid Id,
    Guid SourceId,
    string CustomUrl,
    string? WelcomeMessage,
    string SourceType,
    DateTime CreatedAt
); 