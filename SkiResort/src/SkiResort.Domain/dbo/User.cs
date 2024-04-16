using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Domain.dbo;

public class User : IdentityUser<Guid>
{
    public required string FirstName;
}
