using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts.dboContracts.SkiLesson;
using SkiResort.Domain.dbo;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkiLessonController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, SkiLesson> repository;

        public SkiLessonController(
            IEntityRepositoryBase<int, SkiLesson> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSkiLessonDto createSkiLessonDto)
        {
            var client = createSkiLessonDto.Adapt<SkiLesson>();

            var newSkiLesson = (await repository.Create(client)).Adapt<CreateSkiLessonDto>();

            return Created(
                nameof(newSkiLesson),
                newSkiLesson);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(SkiLessonDto updateDeleteSkiLessonDto)
        {
            var client = updateDeleteSkiLessonDto.Adapt<SkiLesson>();

            await repository.Delete(client);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(SkiLessonDto updateDeleteSkiLessonDto)
        {
            var client = updateDeleteSkiLessonDto.Adapt<SkiLesson>();

            var updatedSkiLesson = (await repository.Update(client)).Adapt<SkiLessonDto>();

            return Ok(updatedSkiLesson);
        }

        [HttpGet("SkiLessonGetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = (await repository.GetById(id)).Adapt<SkiLessonDto>();

            if (client is null)
            {
                return NoContent();
            }

            return Ok(client);
        }

        [HttpGet("SkiLessonGetAll")]
        public async Task<IActionResult> GetAll()
        {
            var clients = (await repository.GetAll()).AsQueryable();

            var clientDtos = clients.ProjectToType<SkiLessonDto>();

            if (clientDtos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(clientDtos);
        }
    }
}
