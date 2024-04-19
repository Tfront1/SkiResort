using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Contracts.dboContracts.EquipmentRental;

public class EquipmentRentalDto
{
    public int Id { get; set; }
    public int EquipmentId { get; set; }
    public int ClientId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal RentalPrice { get; set; }
}
