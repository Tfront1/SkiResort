using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class SkiLesson : IKeyedEntity<int>
{
    [Key]
    public int Id { get; set; }
    public int InstructorId { get; set; }
    public int ClientId { get; set; }
    public DateTime StartDate { get; set; }
    public TimeSpan Duration { get; set; }
    public required Instructor Instructor { get; set; }
    public required Client Client { get; set; }
}