using Application.DTOs.Faqs.CreateFaqDTOs;
using Application.DTOs.Faqs.DeleteFaqDTOs;
using Application.DTOs.Faqs.GetFaqDTOs;
using Application.DTOs.Faqs.ImportFaqsDTOs;
using Application.DTOs.Faqs.UpdateFaqDTOs;

namespace Application.Services.Faqs;
public interface IFaqService
{
    Task<GetFaqWithPageResponseDto> GetFaqsBySourceIdAsync(Guid sourceId);
    Task<CreateFaqResponseDto> CreateFaqAsync(CreateFaqRequestDto requestDto);
    Task<UpdateFaqResponseDto> UpdateFaqAsync(UpdateFaqRequestDto request);
    Task<DeleteFaqResponseDto> DeleteFaqAsync(DeleteFaqRequestDto request);
    Task<ImportResult> ImportFaqs(Stream arquivo, string nomeArquivo, Guid userId);
}