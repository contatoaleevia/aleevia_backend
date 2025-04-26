using System;
using System.Collections.Generic;

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
    public List<SubSpecialtyDto> Subspecialties { get; set; } = null!;
}

public class ProfessionDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public List<SpecialtyDto> Specialties { get; set; } = null!;
}

public class GetProfessionalProfessionsResponseDto
{
    public List<ProfessionDto> Professions { get; set; } = null!;
} 