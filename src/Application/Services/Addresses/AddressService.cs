using Application.DTOs.Adresses.CreateAdressDTOs;
using Application.DTOs.Adresses.GetAddressDTOs;
using CrossCutting.Repositories;
using Domain.Entities.Addresses;

namespace Application.Services.Addresses;

public class AddressService(IRepository<Address> repository) : IAddressService
{
    public async Task<GetAddressByIdReponseDto> GetByIdAddress(Guid id)
    {
        var address = await repository.GetByIdAsync(id);
        if (address != null)
            return new GetAddressByIdReponseDto(
                id: address.Id,
                sourceId: address.SourceId,
                source: address.Source,
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
        throw new Exception("Address not found");
    }

    public async Task<CreateAddressResponseDto> CreateAddressAsync(CreateAddressRequestDto requestDto)
    {
        var address = new Address(
            street: requestDto.Street,
            city: requestDto.City,
            state: requestDto.State,
            zipCode: requestDto.ZipCode,
            number: requestDto.Number,
            neighborhood: requestDto.Neighborhood);

        var response = await repository.CreateAsync(address);
        return new CreateAddressResponseDto(response.Id, response.Street, response.Number);
    }
}