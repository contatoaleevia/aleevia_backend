using Application.DTOs.Email;
using Application.DTOs.Professionals;
using Application.DTOs.Users.RetrieveUserDTOs;
using Application.Helpers;
using Application.Services.Users;
using CrossCutting.Databases;
using Domain.Contracts.Repositories;
using Domain.Entities.Professionals;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Application.Services.Professionals;
public class ProfessionalService(
    IProfessionalRepository professionalRepository,
    IUserService userService,
    IEmailService emailService,
    IConfiguration configuration)
    : IProfessionalService
{
    private readonly string _frontendUrl = configuration.GetValue<string>("FrontendUrl") ?? throw new InvalidOperationException("FrontendUrl não configurada no appsettings");

    public async Task<Professional> PreRegisterWhenNotExists(PreRegisterProfessionalRequest request)
    {
        var professional = await professionalRepository.GetByCpfAsync(request.Cpf);
        if (professional is not null)
            return professional;

        using (var scope = ApiTransactionScope.RepeatableRead(true))
        {
            //TODO: Scopo de transação
            //TODO: Trazer tambem informacoes do usuario pra preencher o body do template
            var manager = await userService.CreateProfessionalUserAsync(new CreateProfessionalUserRequest
            (
                request.Email,
                request.Name,
                request.Cpf
            ));

            var newProfessional = new Professional(
                managerId: manager.Id,
                cpf: request.Cpf);

            await professionalRepository.CreateAsync(newProfessional);

            var tempPassword = RandomGenerator.Generate(lenght: 10);

            try
            {
                //TODO: No AccessLink adicionar o link da web
                await emailService.SendEmailAsync(
                    to: request.Email,
                    subject: PreRegisteredEmailTemplate.GetSubject(),
                    body: PreRegisteredEmailTemplate.GetBody(newProfessional.Cpf.Value, tempPassword, _frontendUrl),
                    isHtml: true
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha ao enviar email de pré-cadastro: {ex.Message}");
            }
            //TODO: Finaliza scopo de transação
            scope.Complete();
            return newProfessional;
        }
    }

    public async Task<Guid> CreateProfessional(CreateProfessionalRequestDto requestDto)
    {
        //TODO: Procurar o profissional PRE Registrado para atualizar
        var professional = await professionalRepository.GetByCpfAsync(requestDto.Cpf);

        //TODO: Caso não tenha, retornar erro
        throw new NotImplementedException();
    }
}