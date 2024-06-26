﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkiResort.Domain.dbo;

namespace SkiResort.Infrastructure.Database.Configurations;


public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder
            .HasKey(i => i.Id);

        builder
            .Property(i => i.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(i => i.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasMany(i => i.SkiLessons)
            .WithOne(sl => sl.Instructor)
            .HasForeignKey(sl => sl.InstructorId);
    }
}