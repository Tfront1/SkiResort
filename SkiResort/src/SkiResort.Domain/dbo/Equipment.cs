using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class Equipment
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required ICollection<MaintenanceRequest> MaintenanceRequests { get; set; }
    public required ICollection<EquipmentRental> EquipmentRentals { get; set; }
}