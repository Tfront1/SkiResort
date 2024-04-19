using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Contracts.dboContracts.Role;

public class RoleDto
{
    public int Id { get; set; }
    public required string RoleName { get; set; }
}
