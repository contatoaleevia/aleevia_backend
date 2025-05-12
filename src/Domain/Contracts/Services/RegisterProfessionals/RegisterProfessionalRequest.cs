using System.Text.Json.Serialization;

namespace Domain.Contracts.Services.RegisterProfessionals;

[method:JsonConstructor]
public record RegisterProfessionalRequest(
    string Name,
    string PreferredName,
    string Email,
    string Phone,
    string Cnpj,
    string CorporateName,
    string Cpf,
    string? Website,
    string? Instagram,
    string? Biography,
    ProfessionalProfessionRequest ProfessionData,
    ProfessionalDocumentRequest DocumentData
);

[method:JsonConstructor]
public record ProfessionalProfessionRequest(
    Guid ProfessionId,
    Guid SpecialityId,
    Guid? SubSpecialityId
);

[method:JsonConstructor]
public record ProfessionalDocumentRequest(
    string DocumentType,
    string DocumentNumber,
    string DocumentState
);