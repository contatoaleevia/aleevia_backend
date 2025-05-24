using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.Addresses;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class AddressRepository(ApiDbContext context) : Repository<Address>(context), IAddressRepository;