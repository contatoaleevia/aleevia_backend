using System.Threading.Tasks;
using Application.DTOs.HealthcareProfessionals;
using Domain.Contracts.Repositories;

namespace Application.Services.HealthcareProfessionals;

public class ProfessionService(IProfessionRepository professionRepository) : IProfessionService
{
    public async Task<GetProfessionsResponseDto> GetAllActiveAsync()
    {
        var professions = await professionRepository.GetAllActiveAsync();

        var result = new GetProfessionsResponseDto
        {
            Professions = [.. professions.Select(profession => new ProfessionDto
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
                    }).ToList() ?? []
                }).ToList() ?? []
            })]
        };

        return result;
    }

    public async Task<GetSpecialtiesResponseDto> GetAllActiveSpecialtiesAsync()
    {
        var professions = await professionRepository.GetAllActiveAsync();
        
        var result = new GetSpecialtiesResponseDto
        {
            Specialties = [.. professions
                .SelectMany(p => p.Specialties ?? [])
                .Where(s => s.Active)
                .Select(specialty => new SimpleSpecialtyDto
                {
                    Id = specialty.Id,
                    Name = specialty.Name
                })]
        };

        return result;
    }
} 