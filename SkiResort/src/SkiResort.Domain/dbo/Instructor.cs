using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class Instructor : IKeyedEntity<int>
{
    [Key]
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Specialization { get; set; }
    public required ICollection<SkiLesson> SkiLessons { get; set; }
}