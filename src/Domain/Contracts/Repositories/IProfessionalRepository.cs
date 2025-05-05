using CrossCutting.Repositories;
using Domain.Entities.Professionals;
using Domain.Entities.ValueObjects;

namespace Domain.Contracts.Repositories;
public interface IProfessionalRepository : IRepository<Professional>
{
    Task<Professional?> GetByCpfAsync(Document cpf);
}