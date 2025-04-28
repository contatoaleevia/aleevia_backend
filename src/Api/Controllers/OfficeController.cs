using Application.DTOs.Offices.CreateOfficeDTOs;
using Application.Services.Offices;
using CrossCutting.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/office")]
public class OfficeController(IOfficeService service, IUserSession session) : ControllerBase
{
    [HttpPost]
    [Authorize]
    [Consumes("application/json")]
    public async Task<IActionResult> CreateOffice([FromBody] CreateOfficeRequest request)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await service.CreateOffice(request, session.UserId));
    }
}