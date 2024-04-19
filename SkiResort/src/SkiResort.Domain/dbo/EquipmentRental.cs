using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class EquipmentRental
{
    [Key]
    public Guid Id { get; set; }
    public Guid EquipmentId { get; set; }
    public Guid ClientId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal RentalPrice { get; set; }
    public required Equipment Equipment { get; set; }
    public required Client Client { get; set; }
}
