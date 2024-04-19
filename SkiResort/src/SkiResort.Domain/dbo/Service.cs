using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class Service : IKeyedEntity<int>
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public required ICollection<ServiceOrder> ServiceOrders { get; set; }
}