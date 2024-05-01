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

public class ClientEventCountsConfiguration : IEntityTypeConfiguration<ClientEventCountModel>
{
    public void Configure(EntityTypeBuilder<ClientEventCountModel> builder)
    {
        builder.HasNoKey();
        builder.ToView("client_events_count");
    }
}
