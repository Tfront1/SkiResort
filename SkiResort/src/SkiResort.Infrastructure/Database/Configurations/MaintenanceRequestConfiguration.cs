using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkiResort.Domain.dbo;

namespace SkiResort.Infrastructure.Database.Configurations;

public class MaintenanceRequestConfiguration : IEntityTypeConfiguration<MaintenanceRequest>
{
    public void Configure(EntityTypeBuilder<MaintenanceRequest> builder)
    {
        builder.
            HasKey(mr => mr.Id);

        builder
            .Property(mr => mr.Status)
            .IsRequired();

        builder
            .Property(mr => mr.StartDate)
            .IsRequired();

        builder
            .Property(mr => mr.EndDate)
            .IsRequired();

        builder
            .HasOne(mr => mr.Equipment)
            .WithMany(e => e.MaintenanceRequests)
            .HasForeignKey(mr => mr.EquipmentId);
    }
}
