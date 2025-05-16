using System.ComponentModel.DataAnnotations;
using Domain.Entities.IaChats.Enums;

namespace Application.DTOs.IaChats.CreateIaChatRatingDTOs;

public class CreateIaChatRatingRequestDto
{
    [Required]
    [Range(0, 10, ErrorMessage = "Experiencia geral deve ser entre 0 e 10")]
    public int GeneralRating { get; set; }

    [Required]
    public ExperienceTypeEnum Experience { get; set; }

    [Required]
    [Range(1, 5, ErrorMessage = "Utilidade deve ser entre 1 e 5")]
    public int Utility { get; set; }
    

    [Required]
    public ProblemSolvedTypeEnum ProblemSolved { get; set; }

    public string? Comment { get; set; }
} 