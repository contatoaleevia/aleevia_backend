﻿using CrossCutting.Extensions;
using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.Professionals;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class ProfessionalRepository(ApiDbContext context) : Repository<Professional>(context), IProfessionalRepository
{
    private readonly DbSet<ProfessionalSpecialtyDetail> specialtyDetailsDB = context.Set<ProfessionalSpecialtyDetail>();
    private readonly DbSet<ProfessionalDocument> documentsDB = context.Set<ProfessionalDocument>();

    public async Task<Professional?> GetByCpfToRegisterAsync(string cpf)
        => await DbSet
            .AsNoTracking()
            .Include(x => x.Manager)
            .ThenInclude(x => x.User)
            .Include(x => x.SpecialtyDetails)
            .Include(x => x.Documents)
            .FirstOrDefaultAsync(x => x.Cpf.Value == cpf.RemoveSpecialCharacters());

    public async Task CreateSpecialtyDetailAsync(ProfessionalSpecialtyDetail specialtyDetail, bool saveChanges = true)
    {
        await specialtyDetailsDB.AddAsync(specialtyDetail);
        if (saveChanges)
            await SaveChangesAsync();
    }

    public async Task UpdateSpecialtyDetailsAsync(ProfessionalSpecialtyDetail specialtyDetail, bool saveChanges = true)
    {
        specialtyDetailsDB.Update(specialtyDetail);
        if (saveChanges)
            await SaveChangesAsync();
    }

    public async Task CreateDocumentAsync(ProfessionalDocument document, bool saveChanges = true)
    {
        await documentsDB.AddAsync(document);
        if(saveChanges)
            await SaveChangesAsync();
    }

    public async Task UpdateProfessionalAddressAsync(ProfessionalAddress professionalAddressees, bool saveChanges = true)
    {
        context.Set<ProfessionalAddress>().Update(professionalAddressees);
        if (saveChanges)
            await SaveChangesAsync();
    }

    public async Task CreateProfessionalAddressAsync(ProfessionalAddress newAddress, bool saveChanges = true)
    {
        context.Set<ProfessionalAddress>().Add(newAddress);
        if (saveChanges)
            await SaveChangesAsync();
    }

    public async Task<Professional?> GetByUserIdWithDetailsAsync(Guid userId)
    {
        return await DbSet
            .Include(p => p.Manager)
            .Include(p => p.RegisterStatus)
            .Include(p => p.Documents)
            .Include(p => p.SpecialtyDetails)
                .ThenInclude(sd => sd.Profession)
            .Include(p => p.SpecialtyDetails)
                .ThenInclude(sd => sd.Speciality)
            .Include(p => p.SpecialtyDetails)
                .ThenInclude(sd => sd.SubSpeciality)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Manager.UserId == userId);
    }

    public async Task<Professional?> GetByManagerIdAsync(Guid managerId)
    {
        return await DbSet
            .Include(p => p.Manager)
            .FirstOrDefaultAsync(p => p.ManagerId == managerId);
    }

    public override Task<Professional?> GetByIdAsync(Guid id)
    {
        return DbSet
            .Include(x => x.SpecialtyDetails)
            .Include(x => x.Documents)
            .Include(x => x.Addresses)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}