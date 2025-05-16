using Application.DTOs.IaChats.CreateIaChatRatingDTOs;
using Domain.Contracts.Repositories;
using Domain.Entities.IaChats;

namespace Application.Services.IaChats;

public class IaChatRatingService(IIaChatRatingRepository ratingRepository) : IIaChatRatingService
{
    public async Task<CreateIaChatRatingResponseDto> CreateRatingAsync(Guid chatId, CreateIaChatRatingRequestDto requestDto)
    {
        var rating = new IaChatRating(
            chatId: chatId,
            generalRating: requestDto.GeneralRating,
            experienceType: requestDto.Experience,
            utility: requestDto.Utility,
            problemSolvedType: requestDto.ProblemSolved,
            comment: requestDto.Comment
        );

        var createdRating = await ratingRepository.CreateAsync(rating);

        return new CreateIaChatRatingResponseDto
        {
            Id = createdRating.Id,
            ChatId = createdRating.ChatId,
            GeneralRating = createdRating.GeneralRating,
            Experience = createdRating.GetExperience(),
            Utility = createdRating.Utility,
            ProblemSolved = createdRating.GetProblemSolved(),
            Comment = createdRating.Comment,
            CreatedAt = createdRating.CreatedAt
        };
    }
} 