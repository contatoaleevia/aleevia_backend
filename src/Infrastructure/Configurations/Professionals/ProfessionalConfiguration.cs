using Domain.Entities.Professionals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Professionals;
public class ProfessionalConfiguration : IEntityTypeConfiguration<Professional>
{
    public void Configure(EntityTypeBuilder<Professional> builder)
    {
        builder.ToTable("professional");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasOne(x => x.Manager)
            .WithMany()
            .HasForeignKey(x => x.ManagerId);  

        builder.OwnsOne(x => x.RegisterStatus, sourceType =>
        {
            sourceType.Property(x => x.StatusType)
                .HasColumnName("status")
                .HasMaxLength(50)
                .IsRequired();
        });

        builder.HasOne(x => x.Office)
            .WithMany()
            .HasForeignKey(x => x.OfficeId);

        builder.OwnsOne(x => x.Cpf, sourceType =>
        {
            sourceType.Property(x => x.Value)
                .HasColumnName("cpf")
                .HasMaxLength(14)
                .IsRequired();
        });

        builder.OwnsOne(x => x.Website, sourceType =>
        {
            sourceType.Property(x => x.Value)
                .HasColumnName("website")
                .HasMaxLength(200);
        });

        builder.OwnsOne(x => x.Instagram, sourceType =>
        {
            sourceType.Property(x => x.Value)
                .HasColumnName("instagram")
                .HasMaxLength(200);
        });

        builder.OwnsOne(x => x.Linkedin, sourceType =>
        {
            sourceType.Property(x => x.Value)
                .HasColumnName("linkedin")
                .HasMaxLength(200);
        });

        builder.OwnsOne(x => x.Doctoralia, sourceType =>
        {
            sourceType.Property(x => x.Value)
                .HasColumnName("doctoralia")
                .HasMaxLength(200);
        });

        builder.OwnsOne(x => x.Biography, sourceType =>
        {
            sourceType.Property(x => x.Value)
                .HasColumnName("biography")
                .HasMaxLength(200);
        });

        builder.OwnsOne(x => x.PictureUrl, sourceType =>
        {
            sourceType.Property(x => x.Value)
                .HasColumnName("picture_url")
                .HasMaxLength(200);
        });

        builder.Property(x => x.GoogleToken)
            .HasColumnName("google_token")
            .HasMaxLength(200);

        builder.Property(x => x.GoogleRefreshToken)
            .HasColumnName("google_refresh_token")
            .HasMaxLength(200);

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at");

        builder.Property(x => x.DeletedAt)
            .HasColumnName("deleted_at");
    }
}