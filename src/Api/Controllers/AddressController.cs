using Application.DTOs.Addresses.CreateAddressDTOs;
using Application.Services;
using Application.Services.Addresses;
using CrossCutting.Session;
using Domain.Exceptions;
using Domain.Exceptions.UserSessions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/address")]
public class AddressController(IAddressService addressService, IUserSession userSession) : ControllerBase
{
    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAddressById(Guid id)
    {
        return Ok(await addressService.GetByIdAddress(id));
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAddress([FromBody] CreateAddressRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await addressService.CreateAddressAsync(requestDto);
        return Ok(response);
    }

    [HttpGet("by-source")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAddressBySourceId()
    {
        if (userSession.ManagerId is null)
            return BadRequest(new ManagerIdNotExistsException());
        return Ok(await addressService.GetAddressBySourceId(userSession.UserId, userSession.ManagerId.Value));
    }
}