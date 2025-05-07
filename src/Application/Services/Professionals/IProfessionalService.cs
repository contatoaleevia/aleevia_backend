using Application.DTOs.Professionals;

namespace Application.Services.Professionals;
public interface IProfessionalService
{
    Task<Guid> CreateProfessional(CreateProfessionalRequestDto requestDto);
    Task<Guid> BindProfessionalOffice(BindProfessionalOfficeRequestDto requestDto);
    Task<Guid> PreCreateProfessional(PreCreateProfessionalRequestDto requestDto);
}