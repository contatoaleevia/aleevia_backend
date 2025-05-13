using Domain.Entities.Professionals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Professionals;

public class ProfessionalSpecialtyDetailConfiguration : IEntityTypeConfiguration<ProfessionalSpecialtyDetail>
{
    public void Configure(EntityTypeBuilder<ProfessionalSpecialtyDetail> builder)
    {
        builder.ToTable("professional_specialty_details");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProfessionalId)
            .IsRequired()
            .HasColumnName("professional_id");

        builder.HasOne(x => x.Professional)
            .WithMany(p => p.SpecialtyDetails)
            .HasForeignKey(x => x.ProfessionalId);

        builder.Property(x => x.ProfessionId)
            .IsRequired()
            .HasColumnName("profession_id");

        builder.HasOne(x => x.Profession)
            .WithMany()
            .HasForeignKey(x => x.ProfessionId);

        builder.Property(x => x.SpecialityId)
            .IsRequired()
            .HasColumnName("speciality_id");

        builder.HasOne(x => x.Speciality)
            .WithMany()
            .HasForeignKey(x => x.SpecialityId);

        builder.Property(x => x.SubspecialityId)
            .HasColumnName("subspeciality_id");

        builder.HasOne(x => x.Subspeciality)
            .WithMany()
            .HasForeignKey(x => x.SubspecialityId);

        builder.Property(x => x.VideoPresentation)
            .HasColumnName("video_presentation");

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at");

        builder.Property(x => x.RemovedAt)
            .HasColumnName("removed_at");
    }
} 