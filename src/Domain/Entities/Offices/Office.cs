using CrossCutting.Entities;
using Domain.Entities.Identities;
using Domain.Utils.ValueObjects;

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
    public Url Logo { get; private set; }

    public Manager Owner { get; set; }

    private Office()
    {
    }

    public Office(Manager owner, string name, string? cnpj, string? phoneNumber, string? whatsapp, string? email,
        string? site, string? instagram, string? logo)
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

    private Url SetLogo(string? logo)
        => logo is null ? Url.CreateAsEmpty() : Url.Create(logo);
}