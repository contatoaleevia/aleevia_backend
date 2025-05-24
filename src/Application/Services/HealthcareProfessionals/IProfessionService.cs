using Application.DTOs.HealthcareProfessionals;

namespace Application.Services.HealthcareProfessionals;

public interface IProfessionService
{
    Task<GetProfessionsResponseDto> GetAllActiveAsync();
    Task<GetSpecialtiesResponseDto> GetAllActiveSpecialtiesAsync();
} 