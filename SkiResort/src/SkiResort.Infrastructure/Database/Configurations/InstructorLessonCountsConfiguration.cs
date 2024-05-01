using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkiResort.Domain.dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Infrastructure.Database.Configurations;

public class InstructorLessonCountsConfiguration : IEntityTypeConfiguration<InstructorLessonCountModel>
{
    public void Configure(EntityTypeBuilder<InstructorLessonCountModel> builder)
    {
        builder.HasNoKey();
        builder.ToView("instructor_lessons_count");
    }
}
