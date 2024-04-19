using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts.dboContracts.Instructor;
using SkiResort.Domain.dbo;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int,Instructor> repository;

        public InstructorController(
            IEntityRepositoryBase<int, Instructor> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInstructorDto createInstructorDto)
        {
            var client = createInstructorDto.Adapt<Instructor>();

            var newInstructor = (await repository.Create(client)).Adapt<CreateInstructorDto>();

            return Created(
                nameof(newInstructor),
                newInstructor);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(InstructorDto updateDeleteInstructorDto)
        {
            var client = updateDeleteInstructorDto.Adapt<Instructor>();

            await repository.Delete(client);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(InstructorDto updateDeleteInstructorDto)
        {
            var client = updateDeleteInstructorDto.Adapt<Instructor>();

            var updatedInstructor = (await repository.Update(client)).Adapt<InstructorDto>();

            return Ok(updatedInstructor);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = (await repository.GetById(id)).Adapt<InstructorDto>();

            if (client is null)
            {
                return NoContent();
            }

            return Ok(client);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var clients = (await repository.GetAll()).AsQueryable();

            var clientDtos = clients.ProjectToType<InstructorDto>();

            if (clientDtos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(clientDtos);
        }
    }
}
