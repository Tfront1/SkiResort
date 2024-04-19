using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkiResort.Domain.dbo;

namespace SkiResort.Infrastructure.Database.Configurations;

public class SkiLessonConfiguration : IEntityTypeConfiguration<SkiLesson>
{
    public void Configure(EntityTypeBuilder<SkiLesson> builder)
    {
        builder
            .HasKey(sl => sl.Id);

        builder
            .Property(sl => sl.StartDate)
            .IsRequired();

        builder
            .Property(sl => sl.Duration)
            .IsRequired();

        builder
            .HasOne(sl => sl.Instructor)
            .WithMany(i => i.SkiLessons)
            .HasForeignKey(sl => sl.InstructorId);

        builder
            .HasOne(sl => sl.Client)
            .WithMany(c => c.SkiLessons)
            .HasForeignKey(sl => sl.ClientId);
    }
}
