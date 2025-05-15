using Application.DTOs.Faqs.GetFaqPageDTOs;

namespace Application.DTOs.Faqs.GetFaqDTOs;

public class GetFaqWithPageResponseDto
{
    public GetFaqPageResponseDto? FaqPage { get; set; }
    public List<GetFaqByProfessionalIdResponseDto> Faqs { get; set; } = [];
} 