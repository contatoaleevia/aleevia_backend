using Domain.Doctors.Entities;
using Infrastructure.Doctors.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
    DbSet<Doctor> Doctors { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasDefaultSchema("public");
        builder.ApplyConfiguration(new DoctorConfiguration());

        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }
    }
}