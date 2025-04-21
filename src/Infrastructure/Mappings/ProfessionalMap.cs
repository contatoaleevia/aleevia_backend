using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class ProfessionalMap : IEntityTypeConfiguration<Professional>
    {
        public void Configure(EntityTypeBuilder<Professional> builder)
        {
            builder.ToTable("professionals");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(x => x.Active)
                .HasColumnName("active")
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnName("status")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.EmailVerified)
                .HasColumnName("email_verified")
                .IsRequired();

            builder.Property(x => x.Phone)
                .HasColumnName("phone")
                .HasMaxLength(20);

            builder.Property(x => x.PhoneVerified)
                .HasColumnName("phone_verified")
                .IsRequired();

            builder.Property(x => x.CNPJ)
                .HasColumnName("cnpj")
                .HasMaxLength(14);

            builder.Property(x => x.Password)
                .HasColumnName("password")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.FaqUrl)
                .HasColumnName("faq_url")
                .HasMaxLength(255);

            builder.Property(x => x.Website)
                .HasColumnName("website")
                .HasMaxLength(255);

            builder.Property(x => x.Instagram)
                .HasColumnName("instagram")
                .HasMaxLength(255);

            builder.Property(x => x.LinkedIn)
                .HasColumnName("linkedin")
                .HasMaxLength(255);

            builder.Property(x => x.Doctoralia)
                .HasColumnName("doctoralia")
                .HasMaxLength(255);

            builder.Property(x => x.Biography)
                .HasColumnName("biography")
                .HasColumnType("text");

            builder.Property(x => x.PictureUrl)
                .HasColumnName("picture_url")
                .HasMaxLength(255);

            builder.Property(x => x.GoogleToken)
                .HasColumnName("google_token")
                .HasColumnType("text");

            builder.Property(x => x.GoogleRefreshToken)
                .HasColumnName("google_refresh_token")
                .HasColumnType("text");

            builder.Property(x => x.PreRegister)
                .HasColumnName("pre_register")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");

            builder.Property(x => x.RemovedAt)
                .HasColumnName("removed_at");

            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Phone).IsUnique();
            builder.HasIndex(x => x.CNPJ).IsUnique();

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);
        }
    }
} 