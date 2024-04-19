using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class Room
{
    [Key]
    public int Id { get; set; }
    public required string Type { get; set; }
    public decimal PricePerNight { get; set; }
    public int Capacity { get; set; }
    public required ICollection<Booking> Bookings { get; set; }
}
