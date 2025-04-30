using Application.DTOs.Adresses.CreateAdressDTOs;
using Application.DTOs.Adresses.GetAddressDTOs;

namespace Application.Services.Addresses;
public interface IAddressService
{
    Task<GetAddressByIdReponseDto> GetByIdAddress(Guid id);
    Task<CreateAddressResponseDto> CreateAddressAsync(CreateAddressRequestDto requestDto);
}