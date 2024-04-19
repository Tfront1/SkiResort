using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Contracts.dboContracts.Instructor;

public class CreateInstructorDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Specialization { get; set; }
}
