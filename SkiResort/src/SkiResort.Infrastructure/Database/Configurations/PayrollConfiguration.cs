using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkiResort.Domain.dbo;

namespace SkiResort.Infrastructure.Database.Configurations;

public class PayrollConfiguration : IEntityTypeConfiguration<Payroll>
{
    public void Configure(EntityTypeBuilder<Payroll> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Amount)
            .HasColumnType("decimal(18,2)");

        builder
            .Property(p => p.PayDate)
            .IsRequired();

        builder
            .HasOne(p => p.Employee)
            .WithMany(e => e.Payrolls)
            .HasForeignKey(p => p.EmployeeId);
    }
}
