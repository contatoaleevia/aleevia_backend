using CrossCutting.Entities;
using Domain.Entities.Identities;
using Domain.Entities.Offices;
using Domain.Entities.ValueObjects;

namespace Domain.Entities.Professionals;

public class Professional : AggregateRoot
{
    private Professional()
    {
    }

    public Professional(
        Guid managerId,
        string cpf,
        bool isRegistered,
        string name,
        string email)
    {
        ManagerId = managerId;
        RegisterStatus = isRegistered ? SetRegisterAsApproval() : SetRegisterAsPending();
        Cpf = Document.CreateDocumentAsCpf(cpf);
        Cnpj = null;
        CreatedAt = DateTime.UtcNow;
        DeletedAt = null;
        UpdatedAt = null;
        Name = name;
        Email = email;
    }

    public string? Name { get; private set; } = string.Empty;
    public string? PreferredName { get; private set; } = string.Empty;
    public string? Email { get; private set; } = string.Empty;
    public Manager Manager { get; private set; } = null!;
    public Guid ManagerId { get; private set; }
    public ProfessionalRegisterStatus RegisterStatus { get; private set; } = null!;
    public bool IsRegistered { get; private set; }
    public Document Cpf { get; private set; } = null!;
    public Document? Cnpj { get; private set; }
    public Url? Website { get; private set; }
    public Url? Instagram { get; private set; }
    public Url? Biography { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public ICollection<ProfessionalSpecialtyDetail> SpecialtyDetails { get; private set; } = [];
    public ICollection<ProfessionalDocument> Documents { get; private set; } = [];
    public ICollection<ProfessionalAddress> Addresses { get; set; } = [];

    private ProfessionalRegisterStatus SetRegisterAsPending()
    {
        IsRegistered = false;
        return ProfessionalRegisterStatus.CreateAsPending();
    }

    private ProfessionalRegisterStatus SetRegisterAsApproval()
    {
        IsRegistered = false;
        return ProfessionalRegisterStatus.CreateAsApproved();
    }

    private Document SetDocument(string? document)
        => string.IsNullOrEmpty(document) ? Document.CreateAsEmptyCnpj() : Document.CreateDocumentAsCnpj(document);

    private Url SetWebsite(string? url)
        => url is null ? Url.CreateAsEmpty() : Url.Create(url);

    private Url SetInstagram(string? instagram)
        => instagram is null ? Url.CreateAsEmpty() : Url.Create(instagram);

    private Url SetBiography(string? biography)
        => biography is null ? Url.CreateAsEmpty() : Url.Create(biography);

    public void Register(string name, string preferredName, string email, string cnpj, string? webSite,
        string? instagram, string? biography)
    {
        if (IsRegistered)
            throw new InvalidOperationException("Profissional já está registrado");

        IsRegistered = true;
        RegisterStatus = ProfessionalRegisterStatus.CreateAsApproved();
        Name = name;
        PreferredName = preferredName;
        Email = email;
        Cnpj = SetDocument(cnpj);
        Website = SetWebsite(webSite);
        Instagram = SetInstagram(instagram);
        Biography = SetBiography(biography);
    }

    public void Update(string name, string preferredName, string email, string website, string instagram,
        string biography)
    {
        Name = name;
        PreferredName = preferredName;
        Email = email;
        Website = SetWebsite(website);
        Instagram = SetInstagram(instagram);
        Biography = SetBiography(biography);
    }

    public ProfessionalSpecialtyDetail? GetSpecialityDetail(Guid professionId, Guid specialityId, Guid? subSpecialityId)
        => SpecialtyDetails.FirstOrDefault(x =>
            x.ProfessionId == professionId && x.SpecialityId == specialityId && x.SubSpecialityId == subSpecialityId);
}