namespace Application.DTOs.HealthcareProfessionals;

public class SubSpecialtyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}

public class SpecialtyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public IEnumerable<SubSpecialtyDto> Subspecialties { get; set; } = [];
}

public class ProfessionDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public IEnumerable<SpecialtyDto> Specialties { get; set; } = [];
}

public class GetProfessionsResponseDto
{
    public IEnumerable<ProfessionDto> Professions { get; set; } = [];
} 