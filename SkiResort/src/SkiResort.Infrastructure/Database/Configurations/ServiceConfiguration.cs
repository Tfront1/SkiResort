using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkiResort.Domain.dbo;

namespace SkiResort.Infrastructure.Database.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder
            .HasKey(s => s.Id);

        builder
            .Property(s => s.Name)
            .IsRequired();

        builder
            .Property(s => s.Price)
            .HasColumnType("decimal(18,2)");
    }
}