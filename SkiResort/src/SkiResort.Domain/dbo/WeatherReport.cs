using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class WeatherReport
{
    [Key]
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public required string WeatherCondition { get; set; }
    public int Temperature { get; set; }
}

