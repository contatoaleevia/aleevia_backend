using Application.Doctors.Contracts;
using Application.Doctors.DTOs.CreateDoctor;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Doctors;

public class DoctorController(IDoctorService doctorService) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorRequest request)
    {
        var result = await doctorService.CreateDoctorAsync(request);
        return Ok(result);
    }
}