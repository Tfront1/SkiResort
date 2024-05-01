using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Domain.dbo;
using SkiResort.Infrastructure.Database;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorLessonsCountController : ControllerBase
    {
        protected readonly SkiResortInternalContext context;

        public InstructorLessonsCountController(
            SkiResortInternalContext context)
        {
            this.context = context;
        }

        [HttpGet("InstructorLessonsCountGetAll")]
        public async Task<List<InstructorLessonCountModel>> GetAll()
        {
            return context.InstructorLessonCounts.ToList();
        }
    }
}
