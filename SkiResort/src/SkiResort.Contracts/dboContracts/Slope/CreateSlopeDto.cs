using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Contracts.dboContracts.Slope;

public class CreateSlopeDto
{
    public required string Name { get; set; }
    public required string DifficultyLevel { get; set; }
    public string? Status { get; set; }
}

