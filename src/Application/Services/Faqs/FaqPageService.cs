using Application.DTOs.Faqs.CreateFaqPageDTOs;
using Application.DTOs.Faqs.GetFaqPageDTOs;
using Application.DTOs.Faqs.UpdateFaqPageDTOs;
using Domain.Contracts.Repositories;
using Domain.Entities.Faqs;
using Domain.Exceptions.Faqs;
using Domain.Exceptions.Offices;
using Domain.Exceptions.Professionals;
using Infrastructure.Helpers;
using Microsoft.Extensions.Configuration;

namespace Application.Services.Faqs;

public class FaqPageService(
    IFaqPageRepository repository,
    IProfessionalRepository professionalRepository,
    IOfficeRepository officeRepository,
    IConfiguration configuration) : IFaqPageService
{
    private readonly string _frontendUrl = configuration.GetValue<string>("FrontendUrl") ?? throw new InvalidOperationException("FrontendUrl não configurada no appsettings");

    public async Task<CreateFaqPageResponseDto> CreateFaqPageAsync(CreateFaqPageRequestDto request)
    {
        var existingPage = await repository.GetBySourceIdAsync(request.SourceId);
        if (existingPage != null)
            throw new FaqPageAlreadyExistException(request.SourceId);

        await ValidateSourceAsync(request.SourceId, request.SourceType);

        var sourceHash = HashHelper.EncodeSourceInfo(request.SourceId, (ushort)request.SourceType);
        var fullUrl = $"{_frontendUrl}faq?sourceHash={sourceHash}";

        var faqPage = new FaqPage(
            request.SourceId,
            request.SourceType,
            fullUrl,
            request.WelcomeMessage,
            DateTime.UtcNow
        );

        await repository.CreateAsync(faqPage);

        return new CreateFaqPageResponseDto(
            faqPage.Id,
            faqPage.SourceId,
            faqPage.CustomUrl,
            faqPage.WelcomeMessage,
            faqPage.SourceType.ToString(),
            faqPage.CreatedAt
        );
    }

    private async Task ValidateSourceAsync(Guid sourceId, FaqSourceEnum sourceType)
    {
        _ = (object)(sourceType switch
        {
            FaqSourceEnum.Professional => await professionalRepository.GetByIdAsync(sourceId)
                                ?? throw new ProfessionalIdNotFoundException(sourceId),
            FaqSourceEnum.Office => await officeRepository.GetByIdAsync(sourceId)
                                ?? throw new OfficeNotFoundException(sourceId),
            _ => throw new InvalidOperationException($"SourceType inválido: {sourceType}. Deve ser Professional (0) ou Office (1)"),
        });
    }

    public async Task<UpdateFaqPageResponseDto> UpdateFaqPageAsync(UpdateFaqPageRequestDto request)
    {
        var faqPage = await repository.GetByIdAsync(request.Id) ?? throw new FaqPageNotFoundException(request.Id);

        faqPage.Update(request.WelcomeMessage);

        await repository.UpdateAsync(faqPage);

        return new UpdateFaqPageResponseDto(
            faqPage.Id,
            faqPage.SourceId,
            faqPage.CustomUrl,
            faqPage.WelcomeMessage,
            faqPage.CreatedAt,
            faqPage.UpdatedAt
        );
    }

    public async Task<GetFaqPageResponseDto> GetFaqPageBySourceIdAsync(Guid sourceId)
    {
        var faqPage = await repository.GetBySourceIdAsync(sourceId) ?? throw new FaqPageBySourceIdNotFoundException(sourceId);

        return new GetFaqPageResponseDto(
            faqPage.Id,
            faqPage.SourceId,
            faqPage.CustomUrl,
            faqPage.WelcomeMessage,
            faqPage.CreatedAt,
            faqPage.UpdatedAt
        );
    }
} 