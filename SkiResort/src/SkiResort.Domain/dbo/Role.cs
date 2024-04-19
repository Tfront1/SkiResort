using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class Role
{
    [Key]
    public Guid Id { get; set; }
    public required string RoleName { get; set; }
    public required ICollection<User> Users { get; set; }
}
