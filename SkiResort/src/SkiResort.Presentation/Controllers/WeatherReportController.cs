using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Contracts.dboContracts.WeatherReport;
using SkiResort.Domain.dbo;
using SkiResort.Presentation.Extensions;

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
        public async Task Create(CreateWeatherReportDto req)
        {
            var dto = req.Adapt<WeatherReport>();

            await repository.Create(dto);
        }

        [HttpDelete]
        public async Task Delete(WeatherReportDto req)
        {
            var dto = req.Adapt<WeatherReport>();

            await repository.Delete(dto);
        }

        [HttpPut]
        public async Task Update(WeatherReportDto req)
        {
            var dto = req.Adapt<WeatherReport>();

            await repository.Update(dto);
        }

        [HttpGet("WeatherReportGetById")]
        public async Task<WeatherReportDto> GetById(int id)
        {
            return (await repository.GetById(id)).Adapt<WeatherReportDto>();
        }

        [HttpGet("WeatherReportGetAll")]
        public async Task<List<WeatherReportDto>> GetAll()
        {
            var query = (await repository.GetAll()).AsQueryable();

            var queryDtos = query.ProjectToType<WeatherReportDto>();

            return queryDtos.ToList();
        }

        [HttpPost("WeatherReportGetPaginatedSorted")]
        public async Task<List<WeatherReportDto>> GetPaginated(PaginationSortingRequest paginationSortingRequest)
        {
            var query = (await repository.GetAll()).AsQueryable();

            query = query.ApplyFiltering(paginationSortingRequest.Filter);

            query = query.ApplySorting(paginationSortingRequest.SortBy, paginationSortingRequest.Ascending);

            query = query.ApplyPagination(paginationSortingRequest.PageIndex, paginationSortingRequest.PageSize);

            return query.ProjectToType<WeatherReportDto>().ToList();
        }
    }
}
