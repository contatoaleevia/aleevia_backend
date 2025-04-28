namespace Application.DTOs.ServiceTypes.DeactivateServiceTypeDTOs;

public class DeactivateServiceTypeResponseDto
{
    public Guid Id { get; set; }
    public bool Active { get; set; }
    public DateTime? UpdatedAt { get; set; }
} 