using Domain.Entities.IaChats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.IaChats;

public class IaChatConfiguration : IEntityTypeConfiguration<IaChat>
{
    public void Configure(EntityTypeBuilder<IaChat> builder)
    {
        builder.ToTable("ia_chat");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id");

        builder.Property(x => x.SourceId)
            .HasColumnName("source_id");

        builder.OwnsOne(x => x.SourceType, sourceType =>
        {
            sourceType.Property(x => x.SourceType)
                .IsRequired()
                .HasColumnName("source_type");
        });

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.HasMany(x => x.Messages)
            .WithOne(x => x.IaChat)
            .HasForeignKey(x => x.IaChatId)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 