using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.Agreements;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;
public class AgreementRepository(ApiDbContext context) : Repository<Agreement>(context), IAgreementRepository
{
}