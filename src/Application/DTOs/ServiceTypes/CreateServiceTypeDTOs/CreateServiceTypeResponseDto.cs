namespace Application.DTOs.ServiceTypes.CreateServiceTypeDTOs;

public class CreateServiceTypeResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
} 