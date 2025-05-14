namespace Application.DTOs.Faqs.UpdateFaqPageDTOs;

public class UpdateFaqPageRequestDto
{
    public Guid Id { get; set; }
    public string WelcomeMessage { get; set; } = null!;
} 