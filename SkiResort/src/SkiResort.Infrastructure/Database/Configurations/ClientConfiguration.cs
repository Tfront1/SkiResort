using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkiResort.Domain.dbo;

namespace SkiResort.Infrastructure.Database.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(c => c.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasMany(c => c.Bookings)
            .WithOne(b => b.Client)
            .HasForeignKey(b => b.ClientId);

        builder
            .HasMany(c => c.ServiceOrders)
            .WithOne(so => so.Client)
            .HasForeignKey(so => so.ClientId);

        builder
            .HasMany(c => c.Tickets)
            .WithOne(t => t.Client)
            .HasForeignKey(t => t.ClientId);

        builder
            .HasMany(c => c.EquipmentRentals)
            .WithOne(t => t.Client)
            .HasForeignKey(t => t.ClientId);
    }
}