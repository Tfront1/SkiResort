using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Contracts.dboContracts.Client;
using SkiResort.Domain.dbo;
using System.Linq;

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
        public async Task<IActionResult> Delete(ClientDto updateDeleteClientDto)
        {
            var client = updateDeleteClientDto.Adapt<Client>();

            await repository.Delete(client);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ClientDto updateDeleteClientDto)
        {
            var client = updateDeleteClientDto.Adapt<Client>();

            var updatedClient = (await repository.Update(client)).Adapt<ClientDto>();

            return Ok(updatedClient);
        }

        [HttpGet("ClientGetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = (await repository.GetById(id)).Adapt<ClientDto>();

            if (client is null)
            {
                return NoContent();
            }

            return Ok(client);
        }

        [HttpGet("ClientGetAll")]
        public async Task<IActionResult> GetAll()
        {
            var clients = (await repository.GetAll()).AsQueryable();

            var clientDtos = clients.ProjectToType<ClientDto>();

            if (clientDtos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(clientDtos);
        }

        [HttpPost("ClientGetPaginated")]
        public async Task<List<ClientDto>> GetPaginated(PaginationRequest paginationRequest)
        {
            var clients = (await repository.GetAll()).AsQueryable();

            clients = clients.Skip((paginationRequest.PageIndex -1) * paginationRequest.PageSize);
            clients = clients.Take(paginationRequest.PageSize);

            var clientDtos = clients.ProjectToType<ClientDto>();

            return clientDtos.ToList();
        }
    }
}
