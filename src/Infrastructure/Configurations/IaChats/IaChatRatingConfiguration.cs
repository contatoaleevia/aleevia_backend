using Domain.Entities.IaChats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.IaChats;

public class IaChatRatingConfiguration : IEntityTypeConfiguration<IaChatRating>
{
    public void Configure(EntityTypeBuilder<IaChatRating> builder)
    {
        builder.ToTable("rating_chat");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.GeneralRating)
            .HasColumnName("general")
            .IsRequired();

        builder.Property(x => x.ExperienceType)
            .HasColumnName("experience")
            .IsRequired();

        builder.Property(x => x.Utility)
            .HasColumnName("utility")
            .IsRequired();

        builder.Property(x => x.ProblemSolvedType)
            .HasColumnName("problem_solved")
            .IsRequired();

        builder.Property(x => x.Comment)
            .HasColumnName("comment");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.HasOne(x => x.Chat)
            .WithMany()
            .HasForeignKey(x => x.ChatId)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 