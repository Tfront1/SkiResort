using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class Payroll
{
    [Key]
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PayDate { get; set; }
    public required Employee Employee { get; set; }
}
