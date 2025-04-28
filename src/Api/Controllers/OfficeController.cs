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
    public async Task<IActionResult> CreateOffice(CreateOfficeRequest request)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var ownerId = Guid.Parse("32c9f130-43e1-4ee4-89e5-9dff5818da01"); // Replace with actual owner ID retrieval logic
        return Ok(await service.CreateOffice(request, ownerId));
    }
}