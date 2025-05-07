namespace Application.DTOs.Professionals;

public record BindOfficeProfessionalRequest
(
    PreRegisterProfessionalRequest Professional,
    Guid OfficeId
);