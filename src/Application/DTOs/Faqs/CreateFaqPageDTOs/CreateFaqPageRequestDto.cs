namespace Application.DTOs.Faqs.CreateFaqPageDTOs;

public record CreateFaqPageRequestDto(
    Guid SourceId,
    string? CustomUrl,
    string? WelcomeMessage); 