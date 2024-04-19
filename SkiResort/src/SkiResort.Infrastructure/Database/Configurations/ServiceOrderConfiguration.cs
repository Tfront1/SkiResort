using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkiResort.Domain.dbo;

namespace SkiResort.Infrastructure.Database.Configurations;

public class ServiceOrderConfiguration : IEntityTypeConfiguration<ServiceOrder>
{
    public void Configure(EntityTypeBuilder<ServiceOrder> builder)
    {
        builder
            .HasKey(so => so.Id);

        builder
            .Property(so => so.OrderDate)
            .IsRequired();

        builder
            .HasOne(so => so.Client)
            .WithMany(c => c.ServiceOrders)
            .HasForeignKey(so => so.ClientId);

        builder
            .HasOne(so => so.Service)
            .WithMany(s => s.ServiceOrders)
            .HasForeignKey(so => so.ServiceId);
    }
}
