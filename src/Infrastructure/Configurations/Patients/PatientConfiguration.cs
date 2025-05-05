using Domain.Entities.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Patients;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("patient");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id");

        builder.Property(p => p.UserId)
            .IsRequired()
            .HasColumnName("user_id");

        builder.OwnsOne(p => p.BloodType, bloodType =>
        {
            bloodType.Property(b => b.TypeId)
                .HasColumnName("blood_type");
        });

        builder.OwnsOne(p => p.BiologicalSex, biologicalSex =>
        {
            biologicalSex.Property(b => b.TypeId)
                .HasColumnName("biological_sex");
        });

        builder.Property(p => p.PictureUrl)
            .HasColumnName("picture_url");

        builder.Property(p => p.GoogleToken)
            .HasColumnName("google_token");

        builder.Property(p => p.GoogleRefreshToken)
            .HasColumnName("google_refresh_token");

        builder.Property(p => p.PreRegister)
            .IsRequired()
            .HasColumnName("pre_register");

        builder.OwnsOne(p => p.Gender, gender =>
        {
            gender.Property(g => g.TypeId)
                .HasColumnName("gender");
        });

        builder.Property(p => p.BirthDate)
            .HasColumnName("birth_date");

        builder.Property(p => p.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("updated_at");

        builder.Property(p => p.RemovedAt)
            .HasColumnName("removed_at");

        builder.HasOne(p => p.User)
            .WithOne()
            .HasForeignKey<Patient>(p => p.UserId);
    }
} 