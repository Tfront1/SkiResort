using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkiResort.Domain.dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Infrastructure.Database.Configurations;

public class DatabaseLogModelsConfiguration : IEntityTypeConfiguration<DatabaseLogModel>
{
    public void Configure(EntityTypeBuilder<DatabaseLogModel> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder.ToTable("database_logs");
    }
}
