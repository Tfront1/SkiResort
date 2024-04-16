using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiResort.Domain.dbo;

namespace SkiResort.Infrastructure.Database;

public class SkiResortInternalContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public SkiResortInternalContext(DbContextOptions<SkiResortInternalContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new Configurations.UserConfiguration());
    }
}