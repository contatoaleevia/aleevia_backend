using Api.ApiResponses;
using Application.DTOs.Offices.BindOfficeAddressDTOs;
using Application.DTOs.Offices.CreateOfficeDTOs;
using Application.DTOs.Offices.DeleteOfficeAddressDTOs;
using Application.DTOs.Offices.GetOfficeDTOs;
using Application.DTOs.Professionals;
using Application.Services.Offices;
using CrossCutting.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/office")]
public class OfficeController(IOfficeService service, IUserSession session) : ControllerBase
{
    /// <summary>
    /// Cria um novo local de trabalho (Office). 
    /// </summary>
    /// <param name="request">Objeto com os dados do local de trabalho:
    /// <summary/>Name: Nome do local de trabalho
    /// <summary/>Description: Descrição do local de trabalho (opcional)
    /// <summary/>PhoneNumber: Número de telefone do local de trabalho
    /// </param>
    /// <returns>ID do local de trabalho criado</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateOffice([FromBody] CreateOfficeRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await service.CreateOffice(request, session.UserId));
    }

    /// <summary>
    /// Vincula um endereço a um local de trabalho (Office). 
    /// O endereço deve ser criado previamente pelo Admin da Office.
    /// Caso o AddressId seja vazio, o endereço será considerado como Teleconsulta automaticamente.
    /// </summary>
    /// <param name="request">Objeto com os dados de vinculação:
    /// <summary/>OfficeId: ID do local de trabalho
    /// <summary/>AddressId: ID do endereço a ser vinculado (opcional para teleconsulta)
    /// <summary/>IsTelemedicine: Indica se é um endereço de teleconsulta
    /// </param>
    /// <returns>ID da relação criada entre local de trabalho e endereço</returns>
    [HttpPost("bind-address")]
    [Authorize(Roles = "Admin")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> BindOfficeAddress([FromBody] BindOfficeAddressRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await service.BindOfficeAddress(request, session.UserId));
    }

    /// <summary>
    /// Deleta um endereço de um local de trabalho (Office) (soft delete).
    /// </summary>
    /// <param name="request">Objeto com os dados para exclusão:
    /// <summary/>Id: ID da relação entre local de trabalho e endereço a ser excluída
    /// </param>
    /// <returns>Confirmação da exclusão</returns>
    [HttpDelete("bind-address")]
    [Authorize(Roles = "Admin")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteOfficeAddress([FromBody] DeleteOfficeAddressRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await service.DeleteOfficeAddress(request.Id);
        return Ok();
    }
    
    /// <summary>
    /// Vincula um profissional a um local de trabalho.
    /// </summary>
    /// <param name="request">Objeto com os dados de vinculação:
    /// <summary/>OfficeId: ID do local de trabalho
    /// <summary/>ProfessionalId: ID do profissional a ser vinculado
    /// </param>
    /// <returns>Informações da vinculação criada</returns>
    [HttpPost("bind-professional")]
    [Authorize(Roles = "Admin")]
    [Consumes("application/json")]
    public async Task<IActionResult> BindProfessionalOffice([FromBody] BindOfficeProfessionalRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await service.BindOfficeProfessional(request);
        return Ok(response);
    }

    /// <summary>
    /// Obtém os dados de um local de trabalho (Office) específico.
    /// </summary>
    /// <param name="id">ID do local de trabalho</param>
    /// <returns>Dados do local de trabalho</returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(OfficeResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetOffice(Guid id)
    {
        var response = await service.GetOffice(id);
        return Ok(response);
    }
}
