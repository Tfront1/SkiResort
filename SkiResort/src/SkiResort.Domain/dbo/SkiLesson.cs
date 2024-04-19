using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class SkiLesson
{
    [Key]
    public Guid Id { get; set; }
    public Guid InstructorId { get; set; }
    public Guid ClientId { get; set; }
    public DateTime StartDate { get; set; }
    public TimeSpan Duration { get; set; }
    public required Instructor Instructor { get; set; }
    public required Client Client { get; set; }
}