using System.Threading.Tasks;
using Application.DTOs.HealthcareProfessionals;

namespace Application.Services.HealthcareProfessionals;

public interface IProfessionalProfessionService
{
    Task<GetProfessionalProfessionsResponseDto> GetAllAsync();
} 