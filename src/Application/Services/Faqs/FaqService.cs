using Application.DTOs.Faqs.CreateFaqDTOs;
using Application.DTOs.Faqs.DeleteFaqDTOs;
using Application.DTOs.Faqs.GetFaqDTOs;
using Application.DTOs.Faqs.GetFaqPageDTOs;
using Application.DTOs.Faqs.UpdateFaqDTOs;
using Domain.Contracts.Repositories;
using Domain.Entities.Faqs;
using Domain.Exceptions;
using Application.DTOs.Faqs.ImportFaqsDTOs;
using Application.Helpers;
using Domain.Exceptions.Faq;

namespace Application.Services.Faqs;
public class FaqService(
    IFaqRepository repository,
    IProfessionalRepository professionalRepository,
    IOfficeRepository officeRepository,
    IFaqPageRepository faqPageRepository) : IFaqService
{
    public async Task<GetFaqWithPageResponseDto> GetFaqsBySourceIdAsync(Guid sourceId)
    {
        var faqPage = await faqPageRepository.GetBySourceIdAsync(sourceId);
        var faqs = await repository.GetAllAsync(sourceId);

        return new GetFaqWithPageResponseDto
        {
            FaqPage = faqPage is not null ? new GetFaqPageResponseDto(
                faqPage.Id,
                faqPage.SourceId,
                faqPage.CustomUrl,
                faqPage.WelcomeMessage,
                faqPage.CreatedAt,
                faqPage.UpdatedAt) : null,
            Faqs = [.. faqs.Select(x => new GetFaqByProfessionalIdResponseDto(
                x.Id,
                x.SourceId,
                x.SourceType,
                x.Question,
                x.Answer,
                x.Link,
                x.FaqCategory,
                x.CreatedAt,
                x.UpdatedAt,
                x.DeletedAt
            ))]
        };
    }

    public async Task<GetFaqWithPageResponseDto> GetFaqsByCustomUrlAsync(string customUrl)
    {
        var faqPage = await faqPageRepository.GetByCustomUrlAsync(customUrl) ?? throw new NotFoundException($"Página de FAQ não encontrada para a URL: {customUrl}");
        var faqs = await repository.GetAllAsync(faqPage.SourceId);

        return new GetFaqWithPageResponseDto
        {
            FaqPage = faqPage is not null ? new GetFaqPageResponseDto(
                faqPage.Id,
                faqPage.SourceId,
                faqPage.CustomUrl,
                faqPage.WelcomeMessage,
                faqPage.CreatedAt,
                faqPage.UpdatedAt) : null,
            Faqs = [.. faqs.Select(x => new GetFaqByProfessionalIdResponseDto(
                x.Id,
                x.SourceId,
                x.SourceType,
                x.Question,
                x.Answer,
                x.Link,
                x.FaqCategory,
                x.CreatedAt,
                x.UpdatedAt,
                x.DeletedAt
            ))]
        };
    }

    public async Task<CreateFaqResponseDto> CreateFaqAsync(CreateFaqRequestDto request)
    {
        await ValidateSourceAsync(request.SourceId, request.SourceType);

        var faq = new Faq(
            sourceId: request.SourceId,
            sourceType: request.SourceType,
            question: request.Question,
            answer: request.Answer,
            link: request.Link,
            faqCategory: request.FaqCategory,
            createdAt: DateTime.UtcNow
        );

        await repository.CreateAsync(faq);

        return CreateFaqResponseDto.FromFaq(faq);
    }

    public async Task<ImportResult> ImportFaqs(Stream arquivo, string nomeArquivo, Guid userId)
    {
        if (arquivo is null)
            throw new AnyItemsToImportException();

        var registros = FileToDtoParser.ParseFile<ImportFaqsRequest>(arquivo, nomeArquivo);

        if (registros == null || registros.Count == 0)
            throw new AnyItemsToImportException();

        var faqsImportadas = new List<ImportFaqsRequest>();
        var erros = new List<ImportError>();

        foreach (var dto in registros)
        {
            try
            {
                var entidade = new Faq(
                    sourceId: userId,
                    sourceType: 0,
                    question: dto.Question,
                    answer: dto.Answer,
                    link: dto.Link,
                    faqCategory: ushort.Parse(dto.FaqCategory),
                    createdAt: DateTime.UtcNow
                );

                await repository.CreateAsync(entidade);
                faqsImportadas.Add(dto);
            }
            catch (Exception)
            {
                erros.Add(new ImportError
                {
                    Item = dto,
                    ErrorMessage = "Não foi possível importar o registro"
                });
            }
        }
        return new ImportResult
        {
            Sucesso = faqsImportadas,
            Erros = erros
        };
    }

    public async Task<UpdateFaqResponseDto> UpdateFaqAsync(UpdateFaqRequestDto request)
    {
        var faq = await repository.GetByIdAsync(request.Id) ?? throw new FaqNotFoundException(request.Id);

        faq.Update(
            question: request.Question,
            answer: request.Answer,
            link: request.Link,
            faqCategory: request.FaqCategory
        );

        await repository.UpdateAsync(faq);

        return UpdateFaqResponseDto.FromFaq(faq);
    }

    public async Task<DeleteFaqResponseDto> DeleteFaqAsync(DeleteFaqRequestDto request)
    {
        var faq = await repository.GetByIdAsync(request.Id) ?? throw new FaqNotFoundException(request.Id);

        faq.Delete();
        await repository.UpdateAsync(faq);

        return DeleteFaqResponseDto.FromFaq(faq);
    }

    private async Task ValidateSourceAsync(Guid sourceId, ushort sourceType)
    {
        var exists = sourceType switch
        {
            (ushort)FaqSourceEnum.Professional => await professionalRepository.GetByIdAsync(sourceId) is not null,
            (ushort)FaqSourceEnum.Office => await officeRepository.GetByIdAsync(sourceId) is not null,
            _ => throw new ArgumentException("Tipo de fonte inválido")
        };

        if (!exists) throw new NotFoundException($"Não foi possível encontrar a fonte com o id: {sourceId}");
    }
}