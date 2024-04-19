using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Contracts.dboContracts.Room;

public class CreateRoomDto
{
    public required string Type { get; set; }
    public decimal PricePerNight { get; set; }
    public int Capacity { get; set; }
}
