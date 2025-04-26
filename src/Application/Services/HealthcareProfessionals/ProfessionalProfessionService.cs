using System.Threading.Tasks;
using Application.DTOs.HealthcareProfessionals;
using Domain.Contracts.Repositories;

namespace Application.Services.HealthcareProfessionals;

public class ProfessionalProfessionService(IProfessionalProfessionRepository repository) : IProfessionalProfessionService
{
    public async Task<GetProfessionalProfessionsResponseDto> GetAllAsync()
    {
        var professions = await repository.GetAllAsync();

        var result = new GetProfessionalProfessionsResponseDto
        {
            Professions = professions.Select(profession => new ProfessionDto
            {
                Id = profession.Id,
                Name = profession.Name,
                Specialties = profession.Specialties?.Select(specialty => new SpecialtyDto
                {
                    Id = specialty.Id,
                    Name = specialty.Name,
                    Subspecialties = specialty.SubSpecialties?.Select(subSpecialty => new SubSpecialtyDto
                    {
                        Id = subSpecialty.Id,
                        Name = subSpecialty.Name
                    }).ToList() ?? new List<SubSpecialtyDto>()
                }).ToList() ?? new List<SpecialtyDto>()
            }).ToList()
        };

        return result;
    }
} 