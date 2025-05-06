using Application.DTOs.Faqs.CreateFaqPageDTOs;
using Application.DTOs.Faqs.GetFaqPageDTOs;
using Application.DTOs.Faqs.UpdateFaqPageDTOs;
using Domain.Contracts.Repositories;
using Domain.Entities.Faqs;
using Domain.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Application.Services.Faqs;

public class FaqPageService(
    IFaqPageRepository repository,
    IConfiguration configuration) : IFaqPageService
{
    private readonly string _frontendUrl = configuration.GetValue<string>("FrontendUrl") ?? throw new InvalidOperationException("FrontendUrl não configurada no appsettings");

    public async Task<CreateFaqPageResponseDto> CreateFaqPageAsync(CreateFaqPageRequestDto request)
    {
        var customUrl = request.CustomUrl ?? request.SourceId.ToString();

        var existingPage = await repository.GetBySourceIdAsync(request.SourceId);
        if (existingPage != null)
            throw new FaqPageAlreadyExistException(request.SourceId);

        var faqPage = new FaqPage(
            request.SourceId,
            customUrl,
            request.WelcomeMessage,
            DateTime.UtcNow
        );

        await repository.CreateAsync(faqPage);
        
        return new CreateFaqPageResponseDto(
            faqPage.Id,
            faqPage.SourceId,
            faqPage.CustomUrl,
            faqPage.WelcomeMessage,
            faqPage.CreatedAt
        );
    }

    public async Task<UpdateFaqPageResponseDto> UpdateFaqPageAsync(UpdateFaqPageRequestDto request)
    {
        var faqPage = await repository.GetByIdAsync(request.Id) ?? throw new FaqPageNotFoundException(request.Id);

        if (request.WelcomeMessage is not null)
            faqPage.Update(request.WelcomeMessage);

        if (request.CustomUrl is not null)
            faqPage.UpdateCustomUrl(request.CustomUrl);

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
        
        var fullUrl = $"{_frontendUrl.TrimEnd('/')}/faq/{faqPage.CustomUrl}";

        return new GetFaqPageResponseDto(
            faqPage.Id,
            faqPage.SourceId,
            faqPage.CustomUrl,
            fullUrl,
            faqPage.WelcomeMessage,
            faqPage.CreatedAt,
            faqPage.UpdatedAt
        );
    }
} 