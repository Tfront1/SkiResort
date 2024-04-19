using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkiResort.Domain.dbo;

namespace SkiResort.Infrastructure.Database.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder
            .HasKey(b => b.Id);

        builder
            .Property(b => b.Status)
            .IsRequired();

        builder
            .Property(b => b.CheckInDate)
            .IsRequired();

        builder
            .Property(b => b.CheckOutDate)
            .IsRequired();

        builder
            .HasOne(b => b.Client)
            .WithMany(c => c.Bookings)
            .HasForeignKey(b => b.ClientId);

        builder
            .HasOne(b => b.Room)
            .WithMany(r => r.Bookings)
            .HasForeignKey(b => b.RoomId);
    }
}