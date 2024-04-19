using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Contracts.dboContracts.Ticket;

public class TicketDto
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public int ClientId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal Price { get; set; }
}
