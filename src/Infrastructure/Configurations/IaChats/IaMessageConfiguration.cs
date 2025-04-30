using Domain.Entities.IaChats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.IaChats;

public class IaMessageConfiguration : IEntityTypeConfiguration<IaMessage>
{
    public void Configure(EntityTypeBuilder<IaMessage> builder)
    {
        builder.ToTable("ia_message");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id");

        builder.HasOne(x => x.IaChat)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.IaChatId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.OwnsOne(x => x.SenderType, senderType =>
        {
            senderType.Property(x => x.SenderType)
                .IsRequired()
                .HasColumnName("sender_type");
        });

        builder.Property(x => x.Message)
            .IsRequired()
            .HasColumnName("message");

        builder.Property(x => x.Content)
            .IsRequired()
            .HasColumnName("content");

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");
    }
} 