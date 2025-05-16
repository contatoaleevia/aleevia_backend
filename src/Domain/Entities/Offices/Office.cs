using CrossCutting.Entities;
using Domain.Entities.Addresses;
using Domain.Entities.Identities;
using Domain.Entities.ValueObjects;
using Domain.Entities.HealthCares;

namespace Domain.Entities.Offices;

public class Office : AggregateRoot
{
    public Guid OwnerId { get; private set; }
    public string Name { get; private set; }
    public Document Cnpj { get; private set; }
    public PhoneNumber Phone { get; private set; }
    public PhoneNumber Whatsapp { get; private set; }
    public Email Email { get; private set; }
    public Url Site { get; private set; }
    public Url Instagram { get; private set; }
    public FileS3 Logo { get; private set; }
    public bool Individual { get; private set; }
    public ICollection<OfficeAddress> Addresses { get; private set; } = [];
    public ICollection<OfficesProfessional> Professionals { get; private set; } = [];
    public ICollection<OfficeSpecialty> Specialties { get; private set; } = [];
    public ICollection<HealthCare> HealthCares { get; private set; } = [];

    public Manager Owner { get; set; } = null!;

    private Office()
    {
    }

    public Office(Manager owner, string name, string? cnpj, string? phoneNumber, string? whatsapp, string? email,
        string? site, string? instagram, FileS3 logo, bool individual = false)
    {
        OwnerId = owner.Id;
        Name = name;
        Cnpj = SetDocument(cnpj);
        Phone = SetPhoneNumber(phoneNumber);
        Whatsapp = SetWhatsapp(whatsapp);
        Email = SetEmail(email);
        Site = SetSite(site);
        Instagram = SetInstagram(instagram);
        Logo = logo;
        Individual = individual;
        Addresses = [];
        Professionals = [];
        Specialties = [];
    }

    private Document SetDocument(string? document)
        => string.IsNullOrEmpty(document) ? Document.CreateAsEmptyCnpj() : Document.CreateDocumentAsCnpj(document);

    private PhoneNumber SetPhoneNumber(string? phone)
        => string.IsNullOrEmpty(phone) ? PhoneNumber.CreateAsEmpty() : PhoneNumber.Create(phone);

    private PhoneNumber SetWhatsapp(string? whatsapp)
        => string.IsNullOrEmpty(whatsapp) ? PhoneNumber.CreateAsEmpty() : PhoneNumber.Create(whatsapp);

    private Email SetEmail(string? email)
        => string.IsNullOrEmpty(email) ? Email.CreateAsEmpty() : Email.Create(email);

    private Url SetSite(string? url)
        => url is null ? Url.CreateAsEmpty() : Url.Create(url);

    private Url SetInstagram(string? instagram)
        => instagram is null ? Url.CreateAsEmpty() : Url.Create(instagram);
    
    public string? GetLogoFileName() => Logo.Id?.ToString();
    public string GetLogoUrl() => Logo.Url;
    public bool HasLogo() => Logo.Id is not null;
    public Guid? GetLogoId() => Logo.Id;
}