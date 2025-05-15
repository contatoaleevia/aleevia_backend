using Domain.Entities.Faqs;

namespace Application.DTOs.Faqs.CreateFaqPageDTOs;

public class CreateFaqPageRequestDto
{
    public required Guid SourceId { get; set; }
    public required FaqSourceEnum SourceType { get; set; }
    public required string WelcomeMessage { get; set; }
} 