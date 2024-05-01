using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Domain.dbo;

public class ClientEventCount
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public int CountOfEvents { get; set; }
}
