using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class Ticket
{
    [Key]
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public Guid ClientId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal Price { get; set; }
    public required Event Event { get; set; }
    public required Client Client { get; set; }
}
