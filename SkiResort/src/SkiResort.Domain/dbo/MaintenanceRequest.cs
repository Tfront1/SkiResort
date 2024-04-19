using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class MaintenanceRequest
{
    [Key]
    public Guid Id { get; set; }
    public Guid EquipmentId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public required string Status { get; set; }
    public required Equipment Equipment { get; set; }
}
