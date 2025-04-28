using Application.DTOs.Adresses.CreateAdressDTOs;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class AddressController(IAddressService addressService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAddressById(Guid id)
    {
        return Ok(await addressService.GetByIdAddress(id));
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateAddress([FromBody] CreateAddressRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await addressService.CreateAddressAsync(requestDto);
        return Ok(response);
    }
}