using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts.dboContracts.Service;
using SkiResort.Domain.dbo;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, Service> repository;

        public ServiceController(
            IEntityRepositoryBase<int, Service> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceDto createServiceDto)
        {
            var client = createServiceDto.Adapt<Service>();

            var newService = (await repository.Create(client)).Adapt<CreateServiceDto>();

            return Created(
                nameof(newService),
                newService);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(ServiceDto updateDeleteServiceDto)
        {
            var client = updateDeleteServiceDto.Adapt<Service>();

            await repository.Delete(client);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ServiceDto updateDeleteServiceDto)
        {
            var client = updateDeleteServiceDto.Adapt<Service>();

            var updatedService = (await repository.Update(client)).Adapt<ServiceDto>();

            return Ok(updatedService);
        }

        [HttpGet("ServiceGetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = (await repository.GetById(id)).Adapt<ServiceDto>();

            if (client is null)
            {
                return NoContent();
            }

            return Ok(client);
        }

        [HttpGet("ServiceGetAll")]
        public async Task<IActionResult> GetAll()
        {
            var clients = (await repository.GetAll()).AsQueryable();

            var clientDtos = clients.ProjectToType<ServiceDto>();

            if (clientDtos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(clientDtos);
        }
    }
}
