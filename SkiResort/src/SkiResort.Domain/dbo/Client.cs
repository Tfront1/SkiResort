using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class Client
{
    [Key]
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public required ICollection<Booking> Bookings { get; set; }
    public required ICollection<ServiceOrder> ServiceOrders { get; set; }
    public required ICollection<Ticket> Tickets { get; set; }
    public required ICollection<SkiLesson> SkiLessons { get; set; }
    public required ICollection<EquipmentRental> EquipmentRentals { get; set; }
}