using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkiResort.Domain.dbo;

namespace SkiResort.Infrastructure.Database.Configurations;

public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
{
    public void Configure(EntityTypeBuilder<Equipment> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.Name)
            .IsRequired();

        builder
            .HasMany(c => c.EquipmentRentals)
            .WithOne(t => t.Equipment)
            .HasForeignKey(t => t.EquipmentId);
    }
}
