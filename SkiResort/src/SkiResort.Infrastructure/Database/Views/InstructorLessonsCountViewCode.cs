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
        i.id AS InstructorId,
        i.first_name AS FirstName,
        COUNT(sl.id) AS CountOfLessons
    FROM 
        instructors i
    LEFT JOIN 
        ski_lessons sl ON i.id = sl.instructor_id
    GROUP BY 
        i.id;
    ";
}
