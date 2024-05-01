using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Domain.dbo;

public class InstructorLessonCount
{
    public int InstructorId { get; set; }
    public string FirstName { get; set; }
    public int CountOfLessons { get; set; }
}
