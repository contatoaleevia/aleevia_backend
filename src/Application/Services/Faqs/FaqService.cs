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
            Faqs = [.. faqs.Select(x => new GetFaqByProfessionalIdResponseDto
            {
                Id = x.Id,
                Question = x.Question,
                Answer = x.Answer,
                SourceId = x.SourceId,
                SourceType = x.SourceType,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            })]
        };
    }

    public async Task<CreateFaqResponseDto> CreateFaqAsync(CreateFaqRequestDto request)
    {
        await ValidateSourceAsync(request.SourceId, request.SourceType);

        var faq = new Faq(
            request.SourceId,
            request.SourceType,
            request.Question,
            request.Answer,
            request.FaqCategory,
            DateTime.UtcNow
        );

        var result = await repository.CreateAsync(faq);

        return new CreateFaqResponseDto(
            id: result.Id,
            question: result.Question,
            answer: result.Answer,
            sourceId: result.SourceId,
            createdAt: result.CreatedAt
        );
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
                var entidade = new Faq
                {
                    SourceId = userId,
                    SourceType = new FaqSourceType(0),
                    Question = dto.Question,
                    Answer = dto.Answer,
                    FaqCategory = new FaqCategoryType(dto.FaqCategory),
                    CreatedAt = DateTime.UtcNow
                };
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

        faq.Question = request.Question;
        faq.Answer = request.Answer;
        faq.UpdatedAt = DateTime.UtcNow;
        faq.FaqCategory = new FaqCategoryType(request.FaqCategory);

        await repository.UpdateAsync(faq);
        return new UpdateFaqResponseDto(
            id: faq.Id,
            sourceId: faq.SourceId,
            sourceType: faq.SourceType,
            question: faq.Question,
            answer: faq.Answer,
            faqCategory: faq.FaqCategory,
            createdAt: faq.CreatedAt,
            updateAt: faq.UpdatedAt
        );
    }

    public async Task<DeleteFaqResponseDto> DeleteFaqAsync(DeleteFaqRequestDto request)
    {
        var faq = await repository.GetByIdAsync(request.Id) ?? throw new FaqNotFoundException(request.Id);

        faq.DeletedAt = DateTime.UtcNow;

        await repository.UpdateAsync(faq);

        return new DeleteFaqResponseDto(
            id: faq.Id,
            sourceId: faq.SourceId,
            sourceType: faq.SourceType,
            question: faq.Question,
            answer: faq.Answer,
            faqCategory: faq.FaqCategory,
            createdAt: faq.CreatedAt,
            updatedAt: faq.UpdatedAt,
            deletedAt: faq.DeletedAt
        );
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