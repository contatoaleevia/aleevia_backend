using Application.DTOs.Faqs.CreateFaqDTOs;
using Application.DTOs.Faqs.DeleteFaqDTOs;
using Application.DTOs.Faqs.GetFaqDTOs;
using Application.DTOs.Faqs.UpdateFaqDTOs;
using Domain.Contracts.Repositories;
using Domain.Entities.Faqs;

namespace Application.Services.Faqs;
public class FaqService(IFaqRepository repository) : IFaqService
{
    public async Task<GetFaqByProfessionalIdResponseDtoList> GetFaqsByProfessionalIdAsync(Guid guid)
    {
        var faq = await repository.GetAllAsync(guid);

        var result = new GetFaqByProfessionalIdResponseDtoList
        {
            Faqs = faq.Select(x => new GetFaqByProfessionalIdResponseDto
            {
                Id = x.Id,
                Question = x.Question,
                Answer = x.Answer,
                SourceId = x.SourceId,
                SourceType = x.SourceType,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            }).ToList()
        };

        return result;
    }

    public async Task<CreateFaqResponseDto> CreateFaqAsync(CreateFaqRequestDto request)
    {
        var faq = new Faq(
            Guid.NewGuid(),
            request.SourceId,
            request.SourceType,
            request.Question,
            request.Answer,
            request.FaqCategory,
            DateTime.Now,
            null,
            null);

        var result = await repository.CreateAsync(faq);

        return new CreateFaqResponseDto(
            id: result.Id,
            question: result.Question,
            answer: result.Answer,
            professionalId: result.SourceId);
    }

    public async Task<UpdateFaqResponseDto> UpdateFaqAsync(UpdateFaqRequestDto request)
    {
        var faq = await repository.GetByIdAsync(request.Id);
        if (faq == null)
            throw new Exception("FAQ não encontrada");

        faq.Question = request.Question;
        faq.Answer = request.Answer;
        faq.UpdatedAt = DateTime.Now;

        await repository.UpdateAsync(faq);
        return new UpdateFaqResponseDto(
            id: faq.Id,
            sourceId: faq.SourceId,
            sourceType: faq.SourceType,
            question: faq.Question,
            answer: faq.Answer,
            faqCategory: faq.FaqCategory,
            createdAt: faq.CreatedAt,
            updateAt: faq.UpdatedAt);
    }

    public async Task<DeleteFaqResponseDto> DeleteFaqAsync(DeleteFaqRequestDto request)
    {
        var faq = await repository.GetByIdAsync(request.Id);
        if (faq == null)
            throw new Exception("FAQ não encontrada");

        faq.DeletedAt = DateTime.Now;

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
            deletedAt: faq.DeletedAt);
    }
}