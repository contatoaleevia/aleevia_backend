using System;
using System.Collections.Generic;

namespace Application.DTOs.HealthcareProfessionals;

public class GetSpecialtiesResponseDto
{
    public IEnumerable<SimpleSpecialtyDto> Specialties { get; set; } = [];
}

public class SimpleSpecialtyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
} 