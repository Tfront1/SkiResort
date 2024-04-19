using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkiResort.Domain.dbo;

namespace SkiResort.Infrastructure.Database.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.Name)
            .IsRequired();

        builder
            .Property(e => e.StartDate)
            .IsRequired();

        builder
            .Property(e => e.EndDate)
            .IsRequired();

        builder
            .Property(e => e.Location)
            .IsRequired();

        builder
            .HasMany(e => e.Tickets)
            .WithOne(t => t.Event)
            .HasForeignKey(t => t.EventId);
    }
}
