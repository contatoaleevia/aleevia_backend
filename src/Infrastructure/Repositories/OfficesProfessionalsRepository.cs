using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.Offices;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;
public class OfficesProfessionalsRepository(ApiDbContext context) : Repository<OfficesProfessionals>(context), IOfficesProfessionalsRepository;