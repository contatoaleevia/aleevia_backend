namespace Application.DTOs.ServiceTypes.DeactivateServiceTypeDTOs;

public class DeactivateServiceTypeResponseDto
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime? UpdatedAt { get; set; }
} 