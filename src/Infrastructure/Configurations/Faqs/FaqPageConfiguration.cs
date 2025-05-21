using Domain.Entities.Faqs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Faqs;
public class FaqPageConfiguration : IEntityTypeConfiguration<FaqPage>
{
    public void Configure(EntityTypeBuilder<FaqPage> builder)
    {
        builder.ToTable("faq_page");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id");

        builder.Property(x => x.SourceId)
            .IsRequired()
            .HasColumnName("source_id");

        builder.Property(x => x.SourceType)
            .IsRequired()
            .HasColumnName("source_type");

        builder.Property(x => x.CustomUrl)
            .IsRequired()
            .HasMaxLength(500)
            .HasColumnName("custom_url");

        builder.Property(x => x.WelcomeMessage)
            .HasMaxLength(500)
            .HasColumnName("welcome_message");

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasIndex(x => x.CustomUrl)
            .IsUnique();
    }
} 