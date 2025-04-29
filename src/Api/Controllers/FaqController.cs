using Application.DTOs.Faqs.CreateFaqDTOs;
using Application.DTOs.Faqs.DeleteFaqDTOs;
using Application.DTOs.Faqs.UpdateFaqDTOs;
using Application.Services.Faqs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/faq")]
public class FaqController(IFaqService faqService) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateFaq([FromBody] CreateFaqRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await faqService.CreateFaqAsync(requestDto);
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetFaqsByProfessionalId(Guid id)
    {
        return Ok(await faqService.GetFaqsByProfessionalIdAsync(id));
    }

    [HttpPatch]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateFaq([FromBody] UpdateFaqRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await faqService.UpdateFaqAsync(requestDto);
        return Ok(response);
    }

    [HttpDelete]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteFaq([FromBody] DeleteFaqRequestDto id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await faqService.DeleteFaqAsync(id);
        return Ok(response);
    }
}