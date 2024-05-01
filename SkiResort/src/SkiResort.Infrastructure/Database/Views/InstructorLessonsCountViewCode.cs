using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Infrastructure.Database.Views;

public static class InstructorLessonsCountViewCode
{
    public static string Code { get; set; } = @"
    CREATE VIEW instructor_lessons_count AS
    SELECT 
        i.id AS instructor_id,
        i.first_name AS first_name,
        COUNT(sl.id) AS count_of_lessons
    FROM 
        instructors i
    LEFT JOIN 
        ski_lessons sl ON i.id = sl.instructor_id
    GROUP BY 
        i.id;
    ";
}
