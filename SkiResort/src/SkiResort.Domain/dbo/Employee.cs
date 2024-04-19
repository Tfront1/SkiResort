using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class Employee
{
    [Key]
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Position { get; set; }
    public required string Department { get; set; }
    public required ICollection<Payroll> Payrolls { get; set; }
}
