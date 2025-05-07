using Application.DTOs.Faqs.CreateFaqPageDTOs;
using Application.DTOs.Faqs.GetFaqPageDTOs;
using Application.DTOs.Faqs.UpdateFaqPageDTOs;

namespace Application.Services.Faqs;

public interface IFaqPageService
{
    Task<CreateFaqPageResponseDto> CreateFaqPageAsync(CreateFaqPageRequestDto request);
    Task<UpdateFaqPageResponseDto> UpdateFaqPageAsync(UpdateFaqPageRequestDto request);
    Task<GetFaqPageResponseDto> GetFaqPageBySourceIdAsync(Guid sourceId);
} 