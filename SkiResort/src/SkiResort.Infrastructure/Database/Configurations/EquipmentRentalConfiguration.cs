using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkiResort.Domain.dbo;

namespace SkiResort.Infrastructure.Database.Configurations;

public class EquipmentRentalConfiguration : IEntityTypeConfiguration<EquipmentRental>
{
    public void Configure(EntityTypeBuilder<EquipmentRental> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.StartDate)
            .IsRequired();

        builder
            .Property(e => e.EndDate)
            .IsRequired();

        builder
            .Property(e => e.RentalPrice)
            .HasColumnType("decimal(18,2)");
    }
}
