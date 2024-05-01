using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkiResort.Domain.dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Infrastructure.Database.Configurations;

public class UserLogModelConfiguration : IEntityTypeConfiguration<UserLogModel>
{
    public void Configure(EntityTypeBuilder<UserLogModel> builder)
    {
        builder
        .HasKey(c => c.Id);

        builder.ToTable("user_logs");
    }
}
