using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class Payroll
{
    [Key]
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PayDate { get; set; }
    public required Employee Employee { get; set; }
}
