using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkiResort.Domain.dbo;

namespace SkiResort.Infrastructure.Database.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder
            .HasKey(t => t.Id);

        builder
            .Property(t => t.PurchaseDate)
            .IsRequired();

        builder
            .Property(t => t.Price)
            .HasColumnType("decimal(18,2)");

        builder.HasOne(t => t.Event)
               .WithMany(e => e.Tickets)
               .HasForeignKey(t => t.EventId);

        builder.HasOne(t => t.Client)
               .WithMany(c => c.Tickets)
               .HasForeignKey(t => t.ClientId);
    }
}
