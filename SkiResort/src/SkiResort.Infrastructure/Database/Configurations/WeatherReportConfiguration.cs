using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkiResort.Domain.dbo;

namespace SkiResort.Infrastructure.Database.Configurations;

public class WeatherReportConfiguration : IEntityTypeConfiguration<WeatherReport>
{
    public void Configure(EntityTypeBuilder<WeatherReport> builder)
    {
        builder
            .HasKey(wr => wr.Id);

        builder
            .Property(wr => wr.Date)
            .IsRequired();

        builder
            .Property(wr => wr.WeatherCondition)
            .IsRequired();

        builder
            .Property(wr => wr.Temperature)
            .IsRequired();
    }
}
