using CrossCutting.Entities;
using Domain.Entities.Identities;
using Domain.Entities.Offices;
using Domain.Entities.ValueObjects;

namespace Domain.Entities.Professionals
{
    public class Professional : AggregateRoot
    {
        private Professional()
        {
        }

        public Professional(
            Guid managerId,
            string cpf)
        {
            ManagerId = managerId;
            RegisterStatus = SetRegisterAsPending();
            Cpf = Document.CreateDocumentAsCpf(cpf);
            Cnpj = null;
            CreatedAt = DateTime.UtcNow;
            DeletedAt = null;
            UpdatedAt = null;
        }

        public Manager Manager { get; private set; } = null!;
        public Guid ManagerId { get; private set; }
        public ProfessionalRegisterStatus RegisterStatus { get; private set; }
        public bool IsRegistered { get; private set; }
        public Document Cpf { get; private set; }
        public Document? Cnpj { get; private set; }
        public Url? Website { get; private set; }
        public Url? Instagram { get; private set; }
        public Url? Biography { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        private ProfessionalRegisterStatus SetRegisterAsPending()
        {
            IsRegistered = false;
            return ProfessionalRegisterStatus.CreateAsPending();
        }
        private Document SetDocument(string? document)
        => string.IsNullOrEmpty(document) ? Document.CreateAsEmptyCnpj() : Document.CreateDocumentAsCnpj(document);
        private Url SetWebsite(string? url)
            => url is null ? Url.CreateAsEmpty() : Url.Create(url);
        private Url SetInstagram(string? instagram)
            => instagram is null ? Url.CreateAsEmpty() : Url.Create(instagram);
        private Url SetBiography(string? biography)
            => biography is null ? Url.CreateAsEmpty() : Url.Create(biography);
    }
}