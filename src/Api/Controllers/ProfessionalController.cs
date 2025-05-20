using Api.ApiResponses;
using Application.DTOs.Professionals.GetProfessionalDTOs;
using Application.DTOs.Professionals.UpdateProfessionalRequestDTOs;
using Application.Services.Professionals;
using CrossCutting.Session;
using Domain.Contracts.Services.RegisterProfessionals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/professional")]
public class ProfessionalController(IProfessionalService service, IUserSession session) : ControllerBase
{
    /// <summary>
    /// Registra Profissional de Saúde Pré Cadastrado.
    /// </summary>
    /// <param name="request">Objeto com os dados do profissional:
    /// <summary/>Name: Nome completo do profissional
    /// <summary/>Email: Email do profissional
    /// <summary/>Document: Documento do profissional (CPF)
    /// <summary/>PhoneNumber: Número de telefone do profissional
    /// <summary/>Specialty: Especialidade do profissional
    /// <summary/>RegisterNumber: Número de registro profissional (CRM, CRO, etc.)
    /// <summary/>RegisterState: Estado do registro profissional (UF)
    /// </param>
    /// <returns>ID do profissional</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateProfessional([FromBody] RegisterProfessionalRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await service.RegisterProfessional(request);
        return Ok(response);
    }

    /// <summary>
    /// Obtém os dados do profissional logado.
    /// </summary>
    /// <returns>Dados completos do profissional</returns>
    [HttpGet("me")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(GetProfessionalResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetMyProfile()
    {
        return Ok(await service.GetProfessionalByUserId(session.UserId));
    }
    
    
    /// <summary>
    /// Atualiza os dados de um Profissional de Saúde existente.
    /// </summary>
    /// <param name="request">Objeto com os dados atualizados do profissional:
    /// <summary/>Name: Nome completo do profissional
    /// <summary/>PreferredName: Nome pelo qual o profissional prefere ser chamado
    /// <summary/>Email: Email profissional para contato
    /// <summary/>Website: Website profissional (opcional)
    /// <summary/>Instagram: Perfil do Instagram profissional (opcional)
    /// <summary/>Biography: Biografia ou descrição profissional
    /// <summary/>ProfessionData: Dados da profissão, especialidade e subespecialidade
    /// <summary/>VideoPresentation: Link para vídeo de apresentação do profissional (ainda não foi incluso opção de S3)
    /// <summary/>AddressId: ID do endereço do profissional
    /// </param>
    /// <param name="id">ID do profissional a ser atualizado</param>
    /// <returns>Confirmação de atualização bem-sucedida</returns>
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateProfessional([FromBody] UpdateProfessionalRequest request, Guid id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await service.UpdateProfessional(request, id);
        return Ok();
    }
}
