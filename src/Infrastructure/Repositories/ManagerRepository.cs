using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.Identities;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class ManagerRepository(ApiDbContext context) : Repository<Manager>(context), IManagerRepository;