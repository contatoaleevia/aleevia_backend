using CrossCutting.Entities;
using Domain.Entities.HealthcareProfessionals;
using Domain.Entities.Identities;
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
        public Profession? Profession { get; private set; }
        public Guid? ProfessionId { get; private set; }
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
        
        public Document SetDocument(string? document)
        => string.IsNullOrEmpty(document) ? Document.CreateAsEmptyCnpj() : Document.CreateDocumentAsCnpj(document);

        public void SetWebsite(string? url) =>
            Website = url is null ? Url.CreateAsEmpty() : Url.Create(url);

        public void SetInstagram(string? instagram)
            => Instagram = instagram is null ? Url.CreateAsEmpty() : Url.Create(instagram);

        public void SetBiography(string? biography)
            => Biography = biography is null ? Url.CreateAsEmpty() : Url.Create(biography);

        public void SetProfession(Guid professionId)
        {
            ProfessionId = professionId;
        }

        public void SetIsRegistered(bool isRegistered)
        {
            IsRegistered = isRegistered;
        }
    }
}