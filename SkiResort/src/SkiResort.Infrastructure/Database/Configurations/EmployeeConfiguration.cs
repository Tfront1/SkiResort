using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkiResort.Domain.dbo;

namespace SkiResort.Infrastructure.Database.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(e => e.Position)
            .IsRequired();

        builder
            .Property(e => e.Department)
            .IsRequired();
    }
}