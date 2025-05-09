using Application.DTOs.Email;
using Application.DTOs.Professionals;
using Application.DTOs.Users.RetrieveUserDTOs;
using Application.Services.Users;
using CrossCutting.Databases;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services.RegisterProfessionals;
using Domain.Entities.Professionals;
using Domain.Exceptions.Professionals;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Application.Services.Professionals;
public class ProfessionalService(
    IProfessionalRepository professionalRepository,
    IUserService userService,
    IEmailService emailService,
    IConfiguration configuration,
    IRegisterProfessional registerProfessional)
    : IProfessionalService
{
    private readonly string _frontendUrl = configuration.GetValue<string>("FrontendUrl") ?? throw new InvalidOperationException("FrontendUrl não configurada no appsettings");

    public async Task<Professional> PreRegisterWhenNotExists(PreRegisterProfessionalRequest request)
    {
        var professional = await professionalRepository.GetByCpfToRegisterAsync(request.Cpf);
        if (professional is not null)
            return professional;

        using var scope = ApiTransactionScope.RepeatableRead(true);
        var (newProfessional, tempPassword) = await userService.CreateProfessionalUserAsync(new CreateProfessionalUserRequest
        (
            request.Email,
            request.Name,
            request.Cpf
        ));

        await professionalRepository.CreateAsync(newProfessional);

        if (tempPassword is not null)
        {
            try
            {
                await emailService.SendEmailAsync(
                    to: request.Email,
                    subject: PreRegisteredEmailTemplate.GetSubject(),
                    body: PreRegisteredEmailTemplate.GetBody(newProfessional.Cpf.GetFormattedValue(), tempPassword, _frontendUrl),
                    isHtml: true
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha ao enviar email de pré-cadastro: {ex.Message}");
            }
        }
        
        scope.Complete();
        return newProfessional;
    }

    public async Task<Guid> RegisterProfessional(RegisterProfessionalRequest request)
    {
        var professional = await professionalRepository.GetByCpfToRegisterAsync(request.Cpf);
        if (professional is null)
            throw new ProfessionalWithCpfNotFoundException(request.Cpf);
        if (professional.IsRegistered)
            throw new ProfessionalAlreadyRegisteredException(request.Cpf);

        registerProfessional.Register(professional, request);

        await professionalRepository.UpdateAsync(professional);
        await professionalRepository.SaveChangesAsync();
        return professional.Id;
    }
}