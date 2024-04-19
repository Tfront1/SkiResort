﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Contracts.dboContracts.SkiLesson;

public class CreateSkiLessonDto
{
    public int InstructorId { get; set; }
    public int ClientId { get; set; }
    public DateTime StartDate { get; set; }
    public TimeSpan Duration { get; set; }
}
