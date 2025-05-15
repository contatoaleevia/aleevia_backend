namespace Application.DTOs.HealthCares.CreateHealthCareDTOs;
public class CreateHealthCareRequest
{
    public Guid OfficeId { get; set; }
    public string Name { get; set; } = null!;
    public string? AnsNumber { get; set; }
    public string? Registration { get; set; }
    public bool Active { get; set; }
}