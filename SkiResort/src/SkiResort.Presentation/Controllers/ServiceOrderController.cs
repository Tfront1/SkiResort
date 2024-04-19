using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts.dboContracts.ServiceOrder;
using SkiResort.Domain.dbo;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceOrderController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, ServiceOrder> repository;

        public ServiceOrderController(
            IEntityRepositoryBase<int, ServiceOrder> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceOrderDto createServiceOrderDto)
        {
            var client = createServiceOrderDto.Adapt<ServiceOrder>();

            var newServiceOrder = (await repository.Create(client)).Adapt<CreateServiceOrderDto>();

            return Created(
                nameof(newServiceOrder),
                newServiceOrder);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(ServiceOrderDto updateDeleteServiceOrderDto)
        {
            var client = updateDeleteServiceOrderDto.Adapt<ServiceOrder>();

            await repository.Delete(client);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ServiceOrderDto updateDeleteServiceOrderDto)
        {
            var client = updateDeleteServiceOrderDto.Adapt<ServiceOrder>();

            var updatedServiceOrder = (await repository.Update(client)).Adapt<ServiceOrderDto>();

            return Ok(updatedServiceOrder);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = (await repository.GetById(id)).Adapt<ServiceOrderDto>();

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

            var clientDtos = clients.ProjectToType<ServiceOrderDto>();

            if (clientDtos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(clientDtos);
        }
    }
}
