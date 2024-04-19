using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class Role : IKeyedEntity<int>
{
    [Key]
    public int Id { get; set; }
    public required string RoleName { get; set; }
    public required ICollection<User> Users { get; set; }
}
