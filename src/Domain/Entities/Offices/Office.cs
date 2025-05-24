using CrossCutting.Entities;
using Domain.Entities.Identities;
using Domain.Entities.ValueObjects;
using Domain.Entities.HealthCares;
using JetBrains.Annotations;

namespace Domain.Entities.Offices;

public class Office : AggregateRoot
{
    public Guid OwnerId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public Document Cnpj { get; private set; } = null!;
    public PhoneNumber Phone { get; private set; } = null!;
    public PhoneNumber Whatsapp { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public Url Site { get; private set; } = null!;
    public Url Instagram { get; private set; } = null!;
    public Url Logo { get; private set; } = null!;
    public bool Individual { get; private set; }
    public ICollection<OfficeAddress> Addresses { get; private set; } = [];
    public ICollection<OfficesProfessional> Professionals { get; private set; } = [];
    public ICollection<OfficeSpecialty> Specialties { get; private set; } = [];
    public ICollection<HealthCare> HealthCares { get; private set; } = [];

    public Manager Owner { get; set; } = null!;

    [UsedImplicitly]
    private Office()
    {
    }

    public Office(Manager owner, string name, string? cnpj, string? phoneNumber, string? whatsapp, string? email,
        string? site, string? instagram, string? logo, bool individual = false)
    {
        OwnerId = owner.Id;
        Name = name;
        Cnpj = SetDocument(cnpj);
        Phone = SetPhoneNumber(phoneNumber);
        Whatsapp = SetWhatsapp(whatsapp);
        Email = SetEmail(email);
        Site = SetSite(site);
        Instagram = SetInstagram(instagram);
        Logo = SetLogo(logo);
        Individual = individual;
        Addresses = [];
        Professionals = [];
        Specialties = [];
    }

    public void Update(string? name = null, string? cnpj = null, string? phoneNumber = null, string? whatsapp = null, 
        string? email = null, string? site = null, string? instagram = null, string? logo = null)
    {
        Name = name ?? Name;
        Cnpj = cnpj != null ? SetDocument(cnpj) : Cnpj;
        Phone = phoneNumber != null ? SetPhoneNumber(phoneNumber) : Phone;
        Whatsapp = whatsapp != null ? SetWhatsapp(whatsapp) : Whatsapp;
        Email = email != null ? SetEmail(email) : Email;
        Site = site != null ? SetSite(site) : Site;
        Instagram = instagram != null ? SetInstagram(instagram) : Instagram;
        Logo = logo != null ? SetLogo(logo) : Logo;
    }

    private static Document SetDocument(string? document)
        => string.IsNullOrEmpty(document) ? Document.CreateAsEmptyCnpj() : Document.CreateDocumentAsCnpj(document);

    private static PhoneNumber SetPhoneNumber(string? phone)
        => string.IsNullOrEmpty(phone) ? PhoneNumber.CreateAsEmpty() : PhoneNumber.Create(phone);

    private static PhoneNumber SetWhatsapp(string? whatsapp)
        => string.IsNullOrEmpty(whatsapp) ? PhoneNumber.CreateAsEmpty() : PhoneNumber.Create(whatsapp);

    private static Email SetEmail(string? email)
        => string.IsNullOrEmpty(email) ? Email.CreateAsEmpty() : Email.Create(email);

    private static Url SetSite(string? url)
        => url is null ? Url.CreateAsEmpty() : Url.Create(url);

    private static Url SetInstagram(string? instagram)
        => instagram is null ? Url.CreateAsEmpty() : Url.Create(instagram);

    private static Url SetLogo(string? logo)
        => logo is null ? Url.CreateAsEmpty() : Url.Create(logo);
}