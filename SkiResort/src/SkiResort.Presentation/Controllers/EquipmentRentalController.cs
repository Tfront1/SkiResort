using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts.dboContracts.EquipmentRental;
using SkiResort.Domain.dbo;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentRentalController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, EquipmentRental> repository;

        public EquipmentRentalController(
            IEntityRepositoryBase<int, EquipmentRental> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEquipmentRentalDto createEquipmentRentalDto)
        {
            var client = createEquipmentRentalDto.Adapt<EquipmentRental>();

            var newEquipmentRental = (await repository.Create(client)).Adapt<CreateEquipmentRentalDto>();

            return Created(
                nameof(newEquipmentRental),
                newEquipmentRental);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(EquipmentRentalDto updateDeleteEquipmentRentalDto)
        {
            var client = updateDeleteEquipmentRentalDto.Adapt<EquipmentRental>();

            await repository.Delete(client);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(EquipmentRentalDto updateDeleteEquipmentRentalDto)
        {
            var client = updateDeleteEquipmentRentalDto.Adapt<EquipmentRental>();

            var updatedEquipmentRental = (await repository.Update(client)).Adapt<EquipmentRentalDto>();

            return Ok(updatedEquipmentRental);
        }

        [HttpGet("EquipmentRentalGetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = (await repository.GetById(id)).Adapt<EquipmentRentalDto>();

            if (client is null)
            {
                return NoContent();
            }

            return Ok(client);
        }

        [HttpGet("EquipmentRentalGetAll")]
        public async Task<IActionResult> GetAll()
        {
            var clients = (await repository.GetAll()).AsQueryable();

            var clientDtos = clients.ProjectToType<EquipmentRentalDto>();

            if (clientDtos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(clientDtos);
        }
    }
}
