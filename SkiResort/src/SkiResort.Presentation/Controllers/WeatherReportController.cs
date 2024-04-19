using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts.dboContracts.WeatherReport;
using SkiResort.Domain.dbo;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherReportController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, WeatherReport> repository;

        public WeatherReportController(
            IEntityRepositoryBase<int, WeatherReport> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWeatherReportDto createWeatherReportDto)
        {
            var client = createWeatherReportDto.Adapt<WeatherReport>();

            var newWeatherReport = (await repository.Create(client)).Adapt<CreateWeatherReportDto>();

            return Created(
                nameof(newWeatherReport),
                newWeatherReport);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(WeatherReportDto updateDeleteWeatherReportDto)
        {
            var client = updateDeleteWeatherReportDto.Adapt<WeatherReport>();

            await repository.Delete(client);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(WeatherReportDto updateDeleteWeatherReportDto)
        {
            var client = updateDeleteWeatherReportDto.Adapt<WeatherReport>();

            var updatedWeatherReport = (await repository.Update(client)).Adapt<WeatherReportDto>();

            return Ok(updatedWeatherReport);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = (await repository.GetById(id)).Adapt<WeatherReportDto>();

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

            var clientDtos = clients.ProjectToType<WeatherReportDto>();

            if (clientDtos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(clientDtos);
        }
    }
}
