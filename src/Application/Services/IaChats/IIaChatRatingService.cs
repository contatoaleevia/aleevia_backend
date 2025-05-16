using Application.DTOs.IaChats.CreateIaChatRatingDTOs;

namespace Application.Services.IaChats;

public interface IIaChatRatingService
{
    Task<CreateIaChatRatingResponseDto> CreateRatingAsync(Guid chatId, CreateIaChatRatingRequestDto requestDto);
} 