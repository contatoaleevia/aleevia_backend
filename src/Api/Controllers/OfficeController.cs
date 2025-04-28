using Application.DTOs.Offices.CreateOfficeDTOs;
using Application.Services.Offices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/office")]
public class OfficeController(IOfficeService service) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [Consumes("application/json")]
    public async Task<IActionResult> CreateOffice([FromBody] CreateOfficeRequest request, [FromHeader] Guid managerId)
    {
        //TODO: Assinar metodo com Authorize(Roles = "Admin") e pegar o userId da UserSession
        if(!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await service.CreateOffice(request, managerId));
    }
}