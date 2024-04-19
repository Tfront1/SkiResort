using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class Service
{
    [Key]
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public required ICollection<ServiceOrder> ServiceOrders { get; set; }
}