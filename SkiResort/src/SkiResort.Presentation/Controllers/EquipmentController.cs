using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts.dboContracts.Equipment;
using SkiResort.Domain.dbo;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, Equipment> repository;

        public EquipmentController(
            IEntityRepositoryBase<int, Equipment> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEquipmentDto createEquipmentDto)
        {
            var client = createEquipmentDto.Adapt<Equipment>();

            var newEquipment = (await repository.Create(client)).Adapt<CreateEquipmentDto>();

            return Created(
                nameof(newEquipment),
                newEquipment);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(EquipmentDto updateDeleteEquipmentDto)
        {
            var client = updateDeleteEquipmentDto.Adapt<Equipment>();

            await repository.Delete(client);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(EquipmentDto updateDeleteEquipmentDto)
        {
            var client = updateDeleteEquipmentDto.Adapt<Equipment>();

            var updatedEquipment = (await repository.Update(client)).Adapt<EquipmentDto>();

            return Ok(updatedEquipment);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = (await repository.GetById(id)).Adapt<EquipmentDto>();

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

            var clientDtos = clients.ProjectToType<EquipmentDto>();

            if (clientDtos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(clientDtos);
        }
    }
}
