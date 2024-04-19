using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class EquipmentRental
{
    [Key]
    public int Id { get; set; }
    public int EquipmentId { get; set; }
    public int ClientId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal RentalPrice { get; set; }
    public required Equipment Equipment { get; set; }
    public required Client Client { get; set; }
}
