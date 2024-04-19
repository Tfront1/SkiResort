using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkiResort.Domain.dbo;

namespace SkiResort.Infrastructure.Database.Configurations;

public class SlopeConfiguration : IEntityTypeConfiguration<Slope>
{
    public void Configure(EntityTypeBuilder<Slope> builder)
    {
        builder
            .HasKey(s => s.Id);

        builder
            .Property(s => s.Name)
            .IsRequired();

        builder
            .Property(s => s.DifficultyLevel)
            .IsRequired();
    }
}
