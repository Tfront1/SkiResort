using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Infrastructure.Database.Views;

public static class ClientEventsCountViewCode
{
    public static string Code { get; set; } = @"
    CREATE VIEW client_events_count AS
    SELECT 
        c.id AS client_id,
        c.first_name AS first_name,
        COUNT(t.id) AS count_of_events
    FROM 
        clients c
    LEFT JOIN 
        tickets t ON c.id = t.client_id
    GROUP BY 
        c.id;
    ";
}
