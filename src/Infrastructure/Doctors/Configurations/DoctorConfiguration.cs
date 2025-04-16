using Domain.Doctors.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Doctors.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("Doctor");
        
        builder.HasKey(d => d.Id);
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}