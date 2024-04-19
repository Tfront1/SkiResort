using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts.dboContracts.Client;
using SkiResort.Domain.dbo;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, Client> repository;

        public ClientController(
            IEntityRepositoryBase<int, Client> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientDto createClientDto)
        {
            var client = createClientDto.Adapt<Client>();

            var newClient = (await repository.Create(client)).Adapt<CreateClientDto>();

            return Created(
                nameof(newClient),
                newClient);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(UpdateDeleteClientDto updateDeleteClientDto)
        {
            var client = updateDeleteClientDto.Adapt<Client>();

            await repository.Delete(client);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDeleteClientDto updateDeleteClientDto)
        {
            var client = updateDeleteClientDto.Adapt<Client>();

            var updatedClient = (await repository.Update(client)).Adapt<UpdateDeleteClientDto>();

            return Ok(updatedClient);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = (await repository.GetById(id)).Adapt<GetClientDto>();

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

            var clientDtos = clients.ProjectToType<GetClientDto>();

            if (clientDtos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(clientDtos);
        }
    }
}
