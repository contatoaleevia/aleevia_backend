using Domain.Entities.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Patients;

public class PatientLeadConfiguration : IEntityTypeConfiguration<PatientLead>
{
    public void Configure(EntityTypeBuilder<PatientLead> builder)
    {
        builder.ToTable("patient_lead");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id");

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Phone)
            .HasColumnName("phone")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(p => p.BirthDate)
            .HasColumnName("birth_date");

        builder.Property(p => p.Email)
            .HasColumnName("email")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Approved)
            .IsRequired()
            .HasColumnName("approved");

        builder.Property(p => p.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("updated_at");

        builder.Property(p => p.RemovedAt)
            .HasColumnName("removed_at");

        builder.OwnsOne(p => p.Cpf, cpf =>
        {
            cpf.Property(c => c.Value)
                .HasColumnName("cpf")
                .HasMaxLength(11)
                .IsRequired();
        });
    }
} 