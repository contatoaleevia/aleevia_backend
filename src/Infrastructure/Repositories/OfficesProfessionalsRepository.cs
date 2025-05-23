﻿using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.Offices;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OfficesProfessionalsRepository(ApiDbContext context) : Repository<OfficesProfessional>(context), IOfficesProfessionalsRepository
{
    public async Task<List<OfficesProfessional>> GetByOfficeIdWithDetailsAsync(Guid officeId)
    {
        return await DbSet
            .Include(op => op.Professional)
                .ThenInclude(p => p.RegisterStatus)
            .Include(op => op.Professional)
                .ThenInclude(p => p.SpecialtyDetails)
                    .ThenInclude(sd => sd.Profession)
            .Include(op => op.Professional)
                .ThenInclude(p => p.SpecialtyDetails)
                    .ThenInclude(sd => sd.Speciality)
            .Include(op => op.Professional)
                .ThenInclude(p => p.SpecialtyDetails)
                    .ThenInclude(sd => sd.SubSpeciality)
            .Include(op => op.Professional)
                .ThenInclude(p => p.Documents)
            .Where(op => op.OfficeId == officeId && op.IsActive)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<OfficesProfessional?> GetByOfficeAndProfessional(Guid officeId, Guid professionalId)
    {
        return await DbSet
            .Include(x => x.Professional)
            .FirstOrDefaultAsync(
                op => op.OfficeId == officeId && 
                    op.ProfessionalId == professionalId
            );
    }

    public async Task<int> CountByOfficeIdAsync(Guid officeId)
    {
        return await DbSet
            .Where(op => op.OfficeId == officeId && op.IsActive)
            .CountAsync();
    }
}