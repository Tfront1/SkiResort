using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class ServiceOrder : IKeyedEntity<int>
{
    [Key]
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int ServiceId { get; set; }
    public DateTime OrderDate { get; set; }
    public required Client Client { get; set; }
    public required Service Service { get; set; }
}
