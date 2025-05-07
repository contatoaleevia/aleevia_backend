namespace Application.DTOs.Faqs.UpdateFaqPageDTOs;

public class UpdateFaqPageRequestDto(Guid id, string? welcomeMessage, string? customUrl)
{
    public Guid Id { get; set; } = id;
    public string? WelcomeMessage { get; set; } = welcomeMessage;
    public string? CustomUrl { get; set; } = customUrl;
} 