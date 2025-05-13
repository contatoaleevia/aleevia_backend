namespace Application.DTOs.Agreements.CreateAgreementDTOs;
public class CreateAgreementRequest
{
    public Guid OfficeId { get; set; }
    public string Name { get; set; }
    public string? AnsNumber { get; set; }
    public string? Registration { get; set; }
    public bool Active { get; set; } = true;
}