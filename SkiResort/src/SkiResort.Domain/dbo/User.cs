using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public Guid RoleId { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; } 
    public DateTime LastLogin { get; set; }
    public required Role Role { get; set; }
}
