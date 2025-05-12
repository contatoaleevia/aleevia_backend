using Application.DTOs.Professionals;
using Application.DTOs.Professionals.GetProfessionalDTOs;
using Domain.Contracts.Services.RegisterProfessionals;
using Domain.Entities.Professionals;

namespace Application.Services.Professionals;

public interface IProfessionalService
{
    Task<Professional> PreRegisterWhenNotExists(PreRegisterProfessionalRequest request);
    Task<ProfessionalResponse> RegisterProfessional(RegisterProfessionalRequest request);
    Task<GetProfessionalResponse> GetProfessionalByUserId(Guid userId);
}