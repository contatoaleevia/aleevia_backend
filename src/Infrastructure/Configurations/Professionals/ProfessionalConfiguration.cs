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

        builder.Property(x => x.ManagerId)
            .HasColumnName("manager_id");

        builder.OwnsOne(x => x.RegisterStatus, sourceType =>
        {
            sourceType.Property(x => x.StatusType)
                .HasColumnName("status")
                .HasMaxLength(50)
                .IsRequired();
        });

        builder.Property(x => x.IsRegistered)
            .HasColumnName("is_registered")
            .IsRequired();

        builder.OwnsOne(x => x.Cpf, sourceType =>
        {
            sourceType.Property(x => x.Value)
                .HasColumnName("cpf")
                .HasMaxLength(14)
                .IsRequired();
        });

        builder.OwnsOne(x => x.Cnpj, sourceType =>
        {
            sourceType.Property(x => x.Value)
                .HasColumnName("cnpj")
                .HasMaxLength(14);
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

        builder.OwnsOne(x => x.Biography, sourceType =>
        {
            sourceType.Property(x => x.Value)
                .HasColumnName("biography")
                .HasMaxLength(200);
        });

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at");

        builder.Property(x => x.DeletedAt)
            .HasColumnName("deleted_at");

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired(false)
            .HasColumnName("name");
        
        builder.Property(x => x.PreferredName)
            .HasMaxLength(100)
            .IsRequired(false)
            .HasColumnName("preferred_name");
        
        builder.Property(x => x.Email)
            .HasMaxLength(100)
            .IsRequired(false)
            .HasColumnName("email");
    }
}