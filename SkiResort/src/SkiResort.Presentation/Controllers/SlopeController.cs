using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts.dboContracts.Slope;
using SkiResort.Domain.dbo;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlopeController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, Slope> repository;

        public SlopeController(
            IEntityRepositoryBase<int, Slope> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSlopeDto createSlopeDto)
        {
            var client = createSlopeDto.Adapt<Slope>();

            var newSlope = (await repository.Create(client)).Adapt<CreateSlopeDto>();

            return Created(
                nameof(newSlope),
                newSlope);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(SlopeDto updateDeleteSlopeDto)
        {
            var client = updateDeleteSlopeDto.Adapt<Slope>();

            await repository.Delete(client);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(SlopeDto updateDeleteSlopeDto)
        {
            var client = updateDeleteSlopeDto.Adapt<Slope>();

            var updatedSlope = (await repository.Update(client)).Adapt<SlopeDto>();

            return Ok(updatedSlope);
        }

        [HttpGet("SlopeGetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = (await repository.GetById(id)).Adapt<SlopeDto>();

            if (client is null)
            {
                return NoContent();
            }

            return Ok(client);
        }

        [HttpGet("SlopeGetAll")]
        public async Task<IActionResult> GetAll()
        {
            var clients = (await repository.GetAll()).AsQueryable();

            var clientDtos = clients.ProjectToType<SlopeDto>();

            if (clientDtos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(clientDtos);
        }
    }
}
