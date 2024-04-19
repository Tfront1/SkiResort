using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;


public class Booking
{
    [Key]
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int RoomId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public required string Status { get; set; }
    public required Client Client { get; set; }
    public required Room Room { get; set; }
}