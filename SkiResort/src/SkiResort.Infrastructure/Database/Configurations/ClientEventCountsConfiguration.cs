using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkiResort.Domain.dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Infrastructure.Database.Configurations;

public class ClientEventCountsConfiguration : IEntityTypeConfiguration<ClientEventCount>
{
    public void Configure(EntityTypeBuilder<ClientEventCount> builder)
    {
        builder.HasNoKey();
        builder.ToView("ClientEventsCount");
    }
}
