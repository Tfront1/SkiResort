using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts.dboContracts.Event;
using SkiResort.Domain.dbo;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, Event> repository;

        public EventController(
            IEntityRepositoryBase<int, Event> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEventDto createEventDto)
        {
            var client = createEventDto.Adapt<Event>();

            var newEvent = (await repository.Create(client)).Adapt<CreateEventDto>();

            return Created(
                nameof(newEvent),
                newEvent);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(EventDto updateDeleteEventDto)
        {
            var client = updateDeleteEventDto.Adapt<Event>();

            await repository.Delete(client);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(EventDto updateDeleteEventDto)
        {
            var client = updateDeleteEventDto.Adapt<Event>();

            var updatedEvent = (await repository.Update(client)).Adapt<EventDto>();

            return Ok(updatedEvent);
        }

        [HttpGet("EventGetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = (await repository.GetById(id)).Adapt<EventDto>();

            if (client is null)
            {
                return NoContent();
            }

            return Ok(client);
        }

        [HttpGet("EventGetAll")]
        public async Task<IActionResult> GetAll()
        {
            var clients = (await repository.GetAll()).AsQueryable();

            var clientDtos = clients.ProjectToType<EventDto>();

            if (clientDtos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(clientDtos);
        }
    }
}
