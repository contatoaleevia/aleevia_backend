using CrossCutting.Entities;
using Domain.Entities.Identities;
using Domain.Entities.Offices;
using Domain.Entities.ValueObjects;
namespace Domain.Entities.Professionals
{
    public class Professional : AggregateRoot
    {
        public Professional()
        {
        }

        public Professional(
            User user,
            Guid userId, 
            ProfessionalStatusType status,
            Guid officeId,
            bool active,
            Document cpf, 
            DateTime createdAt)
        {
            User = user;
            UserId = userId;
            Status = status;
            OfficeId = officeId;
            Active = active;
            Cpf = cpf;
            CreatedAt = createdAt;
        }

        public User User { get; set; }
        public Guid UserId { get; set; }
        public ProfessionalStatusType Status { get; set; }
        public Office Office { get; set; }
        public Guid OfficeId { get; set; }
        public bool Active { get; set; }
        public Document Cpf { get; private set; }
        public Url? Website { get; private set; }
        public Url? Instagram { get; private set; }
        public Url? Linkedin { get; private set; }
        public Url? Doctoralia { get; private set; }
        public Url? Biography { get; private set; }
        public Url? PictureUrl { get; private set; }
        public string? GoogleToken { get; set; }
        public string? GoogleRefreshToken { get; set; }
        public string? PreRegister { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        private Document SetDocument(string? document)
        => string.IsNullOrEmpty(document) ? Document.CreateAsEmptyCnpj() : Document.CreateDocumentAsCnpj(document);
        private Url SetWebsite(string? url)
            => url is null ? Url.CreateAsEmpty() : Url.Create(url);
        private Url SetInstagram(string? instagram)
            => instagram is null ? Url.CreateAsEmpty() : Url.Create(instagram);
        private Url SetLinkedin(string? linkedin)
            => linkedin is null ? Url.CreateAsEmpty() : Url.Create(linkedin);
        private Url SetDoctoralia(string? doctoralia)
            => doctoralia is null ? Url.CreateAsEmpty() : Url.Create(doctoralia);
        private Url SetBiography(string? biography)
            => biography is null ? Url.CreateAsEmpty() : Url.Create(biography);
        private Url SetPictureUrl(string? pictureUrl)
            => pictureUrl is null ? Url.CreateAsEmpty() : Url.Create(pictureUrl);
    }
}