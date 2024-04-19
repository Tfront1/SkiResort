using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Contracts.dboContracts.ServiceOrder;

public class CreateServiceOrderDto
{
    public int ClientId { get; set; }
    public int ServiceId { get; set; }
    public DateTime OrderDate { get; set; }
}
