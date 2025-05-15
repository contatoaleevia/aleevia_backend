using Application.DTOs.Addresses.CreateAddressDTOs;
using Application.DTOs.Addresses.GetAddressDTOs;
using Application.DTOs.Addresses.UpdateAddressDTOs;
using Application.DTOs.Adresses.GetAddressBySourceDTOs;

namespace Application.Services.Addresses;
public interface IAddressService
{
    Task<GetAddressByIdResponseDto> GetByIdAddress(Guid id);
    Task<CreateAddressResponseDto> CreateAddressAsync(CreateAddressRequestDto requestDto);
    Task<IEnumerable<GetAddressBySourceResponse>> GetAddressBySourceId(Guid userId, Guid managerId);
    Task<UpdateAddressResponseDto> UpdateAddressAsync(UpdateAddressRequestDto requestDto);
}