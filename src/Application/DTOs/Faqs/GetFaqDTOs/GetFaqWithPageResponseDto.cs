using Application.DTOs.Faqs.CreateFaqPageDTOs;

namespace Application.DTOs.Faqs.GetFaqDTOs;

public class GetFaqWithPageResponseDto
{
    public CreateFaqPageResponseDto? FaqPage { get; set; }
    public List<GetFaqByProfessionalIdResponseDto> Faqs { get; set; } = [];
} 