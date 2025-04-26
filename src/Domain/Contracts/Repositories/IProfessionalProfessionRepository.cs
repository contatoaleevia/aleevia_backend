using CrossCutting.Repositories;
using Domain.Entities.HealthcareProfessionals;

namespace Domain.Contracts.Repositories;

public interface IProfessionalProfessionRepository : IRepository<Profession>
{
    Task<List<Profession>> GetAllAsync();
}