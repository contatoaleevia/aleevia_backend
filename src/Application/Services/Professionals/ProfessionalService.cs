using Application.DTOs.Email;
using Application.DTOs.Professionals;
using Application.DTOs.Users.RetrieveUserDTOs;
using Application.Helpers;
using Application.Services.Users;
using CrossCutting.Databases;
using Domain.Contracts.Repositories;
using Domain.Entities.Identities;
using Domain.Entities.Offices;
using Domain.Entities.Professionals;
using Domain.Entities.ValueObjects;
using Domain.Exceptions;
using Domain.Exceptions.Offices;
using Domain.Exceptions.Professionals;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Professionals;
public class ProfessionalService(
    IProfessionalRepository professionalRepository, 
    IUserService userService,
    IEmailService emailService) 
    : IProfessionalService
{
    public async Task<Professional> PreRegisterWhenNotExists(PreRegisterProfessionalRequest request)
    {
        var professional = await professionalRepository.GetByCpfAsync(request.Cpf);
        if (professional is not null)
            return professional;

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

        try
        {
            //TODO: No AccessLink adicionar o link da web
            await emailService.SendEmailAsync(
                to: request.Email,
                subject: PreRegisteredEmailTemplate.GetSubject(),
                body: PreRegisteredEmailTemplate.GetBody(manager.Cpf.Value, tempPassword, string.Empty),
                isHtml: true
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Falha ao enviar email de pré-cadastro: {ex.Message}");
        }
        //TODO: Finaliza scopo de transação
        return newProfessional;
    }

    public async Task<Guid> CreateProfessional(CreateProfessionalRequestDto requestDto)
    {
        var user = await userManager.FindByIdAsync(requestDto.UserId.ToString());
        if (user is null)
            throw new UserNotFoundException(requestDto.UserId);

        var professional = new Professional(
            user: user,
            managerId: user.Id,
            registerStatus: new ProfessionalRegisterStatus(requestDto.Status),
            officeId: requestDto.OfficeId,
            active: requestDto.Active,
            cpf: Document.CreateDocumentAsCnpj(requestDto.Cnpj),
            createdAt: DateTime.UtcNow
        );

        try
        {
            var response = await professionalRepository.CreateAsync(professional);
            return response.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new CreateProfessionalException(user.Id);
        }
    }
}