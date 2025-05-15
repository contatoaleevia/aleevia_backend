using Domain.Entities.Faqs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Faqs;
public class FaqConfiguration : IEntityTypeConfiguration<Faq>
{
    public void Configure(EntityTypeBuilder<Faq> builder)
    {
        builder.ToTable("faq", "public");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id");

        builder.Property(x => x.SourceId)
            .IsRequired()
            .HasColumnName("source_id");

        builder.Ignore(x => x.Source);

        builder.OwnsOne(x => x.SourceType, sourceType =>
        {
            sourceType.Property(x => x.SourceType)
                .IsRequired()
                .HasColumnName("source_type");
        });

        builder.Property(x => x.Question)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("question");

        builder.Property(x => x.Answer)
            .IsRequired()
            .HasMaxLength(1000)
            .HasColumnName("answer");

        builder.Property(x => x.Link)
            .IsRequired(false)
            .HasMaxLength(500)
            .HasColumnName("link");

        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasDefaultValue(true)
            .HasColumnName("is_active");

        builder.OwnsOne(x => x.FaqCategory, faqCategory =>
        {
            faqCategory.Property(x => x.CategoryType)
                .IsRequired()
                .HasColumnName("faq_category");
        });

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(x => x.UpdatedAt)
            .IsRequired(false)
            .HasColumnName("updated_at");

        builder.Property(x => x.DeletedAt)
            .IsRequired(false)
            .HasColumnName("deleted_at");
    }
}