using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkiResort.Domain.dbo;

namespace SkiResort.Infrastructure.Database.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder
            .HasKey(r => r.Id);

        builder
            .Property(r => r.Type)
            .IsRequired();

        builder
            .Property(r => r.Capacity)
            .IsRequired();

        builder
            .Property(r => r.PricePerNight)
            .HasColumnType("decimal(18,2)");
    }
}
