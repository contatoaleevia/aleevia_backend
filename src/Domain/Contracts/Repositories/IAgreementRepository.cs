using CrossCutting.Repositories;
using Domain.Entities.HealthCares;

namespace Domain.Contracts.Repositories;
public interface IHealthCareRepository : IRepository<HealthCare>;