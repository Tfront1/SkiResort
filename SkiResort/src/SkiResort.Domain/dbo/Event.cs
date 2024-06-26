﻿using System.ComponentModel.DataAnnotations;

namespace SkiResort.Domain.dbo;

public class Event : IKeyedEntity<int>
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public required string Location { get; set; }
    public required ICollection<Ticket> Tickets { get; set; }
}
