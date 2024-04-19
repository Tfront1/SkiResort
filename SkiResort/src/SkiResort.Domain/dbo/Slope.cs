using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class Slope
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string DifficultyLevel { get; set; }
    public string? Status { get; set; }
}
