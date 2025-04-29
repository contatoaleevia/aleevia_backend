using Domain.Entities.Faqs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Faqs;
public class FaqConfiguration : IEntityTypeConfiguration<Faq>
{
    public void Configure(EntityTypeBuilder<Faq> builder)
    {
        builder.ToTable("faq");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id");

        builder.HasOne(x => x.Source)
            .WithMany()
            .HasForeignKey(x => x.SourceId)
            .OnDelete(DeleteBehavior.Cascade);

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