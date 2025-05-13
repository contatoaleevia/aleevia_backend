using CrossCutting.Repositories;
using Domain.Entities.Agreements;

namespace Domain.Contracts.Repositories;
public interface IAgreementRepository : IRepository<Agreement>;