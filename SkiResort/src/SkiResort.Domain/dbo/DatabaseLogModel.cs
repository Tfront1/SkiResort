using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Domain.dbo;

public class DatabaseLogModel : IKeyedEntity<int>
{
    [Key]
    public int Id { get; set; }

    public DateTime EventDate { get; set; }

    public string TableName { get; set; }
}
