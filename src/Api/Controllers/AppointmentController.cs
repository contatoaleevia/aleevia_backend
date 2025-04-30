using Application.DTOs.Appointments.CreateAppointmentDTOs;
using Application.Services.Appointments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class AppointmentController(IAppointmentService appointmentService) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await appointmentService.CreateAppointmentAsync(requestDto);
        return Ok(response);
    }

    [HttpDelete]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteAppointmentAsync([FromBody] Guid appointmentId)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await appointmentService.DeleteAppointmentAsync(appointmentId);
        return Ok(response);
    }
}