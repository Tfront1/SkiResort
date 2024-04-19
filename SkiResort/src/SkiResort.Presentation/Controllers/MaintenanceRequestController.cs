using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts.dboContracts.MaintenanceRequest;
using SkiResort.Domain.dbo;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceRequestController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, MaintenanceRequest> repository;

        public MaintenanceRequestController(
            IEntityRepositoryBase<int, MaintenanceRequest> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMaintenanceRequestDto createMaintenanceRequestDto)
        {
            var client = createMaintenanceRequestDto.Adapt<MaintenanceRequest>();

            var newMaintenanceRequest = (await repository.Create(client)).Adapt<CreateMaintenanceRequestDto>();

            return Created(
                nameof(newMaintenanceRequest),
                newMaintenanceRequest);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(MaintenanceRequestDto updateDeleteMaintenanceRequestDto)
        {
            var client = updateDeleteMaintenanceRequestDto.Adapt<MaintenanceRequest>();

            await repository.Delete(client);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(MaintenanceRequestDto updateDeleteMaintenanceRequestDto)
        {
            var client = updateDeleteMaintenanceRequestDto.Adapt<MaintenanceRequest>();

            var updatedMaintenanceRequest = (await repository.Update(client)).Adapt<MaintenanceRequestDto>();

            return Ok(updatedMaintenanceRequest);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = (await repository.GetById(id)).Adapt<MaintenanceRequestDto>();

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

            var clientDtos = clients.ProjectToType<MaintenanceRequestDto>();

            if (clientDtos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(clientDtos);
        }
    }
}
