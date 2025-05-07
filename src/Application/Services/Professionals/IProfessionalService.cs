using Application.DTOs.Professionals;
using Domain.Entities.Professionals;

namespace Application.Services.Professionals;
public interface IProfessionalService
{
    Task<Professional> PreRegisterWhenNotExists(PreRegisterProfessionalRequest request);
    Task<Guid> CreateProfessional(CreateProfessionalRequestDto requestDto);
}