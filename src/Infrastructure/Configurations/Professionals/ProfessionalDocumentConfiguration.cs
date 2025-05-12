using Domain.Entities.Professionals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Professionals;

public class ProfessionalDocumentConfiguration : IEntityTypeConfiguration<ProfessionalDocument>
{
    public void Configure(EntityTypeBuilder<ProfessionalDocument> builder)
    {
        builder.ToTable("professional_documents");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProfessionalId)
            .IsRequired()
            .HasColumnName("professional_id");

        builder.HasOne(x => x.Professional)
            .WithMany(p => p.Documents)
            .HasForeignKey(x => x.ProfessionalId);

        builder.Property(x => x.DocumentType)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("document_type");

        builder.Property(x => x.DocumentNumber)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("document_number");

        builder.Property(x => x.DocumentState)
            .IsRequired()
            .HasMaxLength(2)
            .HasColumnName("document_state");

        builder.Property(x => x.FrontUrl)
            .HasColumnName("front_url");

        builder.Property(x => x.BackUrl)
            .HasColumnName("back_url");

        builder.Property(x => x.Validated)
            .IsRequired()
            .HasColumnName("validated");

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(x => x.RemovedAt)
            .HasColumnName("removed_at");
    }
} 