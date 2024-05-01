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
        c.id AS ClientId,
        c.first_name AS FirstName,
        COUNT(t.id) AS CountOfEvents
    FROM 
        clients c
    LEFT JOIN 
        tickets t ON c.id = t.client_id
    GROUP BY 
        c.id;
    ";
}
