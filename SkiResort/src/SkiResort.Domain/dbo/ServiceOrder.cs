using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class ServiceOrder
{
    [Key]
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public Guid ServiceId { get; set; }
    public DateTime OrderDate { get; set; }
    public required Client Client { get; set; }
    public required Service Service { get; set; }
}
