using Application.DTOs.Addresses.CreateAddressDTOs;
using Application.DTOs.Adresses.GetAddressBySourceDTOs;
using Application.DTOs.Adresses.GetAddressDTOs;

namespace Application.Services.Addresses;
public interface IAddressService
{
    Task<GetAddressByIdReponseDto> GetByIdAddress(Guid id);
    Task<CreateAddressResponseDto> CreateAddressAsync(CreateAddressRequestDto requestDto);
    Task<IEnumerable<GetAddressBySourceResponse>> GetAddressBySourceId(Guid userId, Guid managerId);
}