using CrossCutting.Repositories;
using Domain.Entities.Addresses;

namespace Domain.Contracts.Repositories;

public interface IAddressRepository : IRepository<Address>;
