using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts.dboContracts.Ticket;
using SkiResort.Domain.dbo;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, Ticket> repository;

        public TicketController(
            IEntityRepositoryBase<int, Ticket> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTicketDto createTicketDto)
        {
            var client = createTicketDto.Adapt<Ticket>();

            var newTicket = (await repository.Create(client)).Adapt<CreateTicketDto>();

            return Created(
                nameof(newTicket),
                newTicket);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(TicketDto updateDeleteTicketDto)
        {
            var client = updateDeleteTicketDto.Adapt<Ticket>();

            await repository.Delete(client);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(TicketDto updateDeleteTicketDto)
        {
            var client = updateDeleteTicketDto.Adapt<Ticket>();

            var updatedTicket = (await repository.Update(client)).Adapt<TicketDto>();

            return Ok(updatedTicket);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = (await repository.GetById(id)).Adapt<TicketDto>();

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

            var clientDtos = clients.ProjectToType<TicketDto>();

            if (clientDtos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(clientDtos);
        }
    }
}
