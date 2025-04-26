using CrossCutting.Entities;
using Domain.Utils.ValueObjects;

namespace Domain.Entities.Offices;

public class Office : AggregateRoot
{
    public string Name { get; private set; }
    public Document? Cnpj { get; private set; }
    public PhoneNumber? Phone { get; private set; }
    public PhoneNumber? Whatsapp { get; private set; }
    public Email? Email { get; private set; }
    public Url? Site { get; private set; }
    public Url? Instagram { get; private set; }
    public Url? Logo { get; private set; }

    private Office()
    {
    }

    public Office(string name, string? cnpj, string? phoneNumber, string? whatsapp, string? email, string? site,
        string? instagram, string? logo)    
    {
        Name = name;
        Cnpj = SetDocument(cnpj);
        Phone = SetPhoneNumber(phoneNumber);
        Whatsapp = SetPhoneNumber(whatsapp);
        Email = SetEmail(email);
        Site = SetSite(site);
        Instagram = SetInstagram(instagram);
        Logo = SetLogo(logo);
    }

    private Document? SetDocument(string? document)
        => document is null ? null : Document.CreateDocumentAsCnpj(document);

    private PhoneNumber? SetPhoneNumber(string? phone)
        => phone is null ? null : new PhoneNumber(phone);

    private Email? SetEmail(string? email) 
        => email is null ? null : new Email(email);
    
    private Url? SetSite(string? url) 
        => url is null ? null : new Url(url);
    
    private Url? SetInstagram(string? instagram) 
        => instagram is null ? null : new Url(instagram);
    
    private Url? SetLogo(string? logo) 
        => logo is null ? null : new Url(logo);
}