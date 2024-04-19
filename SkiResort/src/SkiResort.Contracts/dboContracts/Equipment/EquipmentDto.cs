using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Contracts.dboContracts.Equipment;

public class EquipmentDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
