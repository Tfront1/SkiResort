using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class Ticket
{
    [Key]
    public int Id { get; set; }
    public int EventId { get; set; }
    public int ClientId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal Price { get; set; }
    public required Event Event { get; set; }
    public required Client Client { get; set; }
}
