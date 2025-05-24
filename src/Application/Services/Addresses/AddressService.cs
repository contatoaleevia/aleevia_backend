using Application.DTOs.Addresses.CreateAddressDTOs;
using Application.DTOs.Addresses.GetAddressBySourceDTOs;
using Application.DTOs.Addresses.GetAddressDTOs;
using Application.DTOs.Addresses.UpdateAddressDTOs;
using Domain.Contracts.Repositories;
using Domain.Entities.Addresses;
using Domain.Entities.Identities;
using Domain.Exceptions.Adresses;
using Domain.Exceptions;
using Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Addresses;

public class AddressService(IAddressRepository repository, UserManager<User> userManager) : IAddressService
{
    public async Task<GetAddressByIdResponseDto> GetByIdAddress(Guid id)
    {
        var address = await repository.GetByIdAsync(id);
        if (address != null)
            return new GetAddressByIdResponseDto(
                id: address.Id,
                sourceId: address.SourceId,
                sourceType: address.SourceType,
                name: address.Name,
                street: address.Street,
                neighborhood: address.Neighborhood,
                number: address.Number,
                city: address.City,
                state: address.State,
                zipCode: address.ZipCode,
                complement: address.Complement,
                type: address.Type,
                location: address.Location,
                createdAt: address.CreatedAt,
                updatedAt: address.UpdatedAt
            );
        throw new AddressNotFoundException(id);
    }

    public async Task<CreateAddressResponseDto> CreateAddressAsync(CreateAddressRequestDto requestDto)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(x =>
            x.Id == requestDto.SourceId) ?? throw new UserNotFoundException(requestDto.SourceId);

        var address = new Address(
            name: requestDto.Name,
            sourceId: requestDto.SourceId,
            sourceType: user.UserType,
            street: requestDto.Street,
            city: requestDto.City,
            state: requestDto.State,
            zipCode: requestDto.ZipCode,
            number: requestDto.Number,
            neighborhood: requestDto.Neighborhood,
            complement: requestDto.Complement,
            type: requestDto.Type);

        var response = await repository.CreateAsync(address);
        return CreateAddressResponseDto.FromAddress(response);
    }

    public async Task<IEnumerable<GetAddressBySourceResponse>> GetAddressBySourceId(Guid userId, Guid managerId)
    {
        var addressIdsNotIn = await repository.GetDbContext<ApiDbContext>()
            .Offices
            .Include(x => x.Owner)
            .Include(x => x.Addresses)
            .AsNoTracking()
            .Where(x => x.OwnerId == managerId)
            .SelectMany(x => x.Addresses)
            .Select(x => x.AddressId)
            .ToListAsync();

        var test = await repository.GetDbContext<ApiDbContext>()
            .Addresses
            .AsNoTracking()
            .Where(x => x.SourceId == userId && !addressIdsNotIn.Contains(x.Id))
            .Select(x => new GetAddressBySourceResponse(
                x.Id,
                x.Name,
                x.Street,
                x.Neighborhood,
                x.Number,
                x.City,
                x.State,
                x.ZipCode,
                x.Complement
            )).ToListAsync();

        return test.OrderByDescending(x => x.Name);
    }

    public async Task<UpdateAddressResponseDto> UpdateAddressAsync(UpdateAddressRequestDto requestDto)
    {
        var address = await repository.GetByIdAsync(requestDto.Id)
            ?? throw new AddressNotFoundException(requestDto.Id);

        address.Update(
            name: requestDto.Name,
            street: requestDto.Street,
            neighborhood: requestDto.Neighborhood,
            number: requestDto.Number,
            city: requestDto.City,
            state: requestDto.State,
            zipCode: requestDto.ZipCode,
            complement: requestDto.Complement);

        await repository.UpdateAsync(address);

        return UpdateAddressResponseDto.FromAddress(address);
    }
}