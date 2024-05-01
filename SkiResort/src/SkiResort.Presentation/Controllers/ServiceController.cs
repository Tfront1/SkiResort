using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Contracts.dboContracts.Service;
using SkiResort.Domain.dbo;
using SkiResort.Presentation.Extensions;

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
        public async Task Create(CreateServiceDto req)
        {
            var dto = req.Adapt<Service>();

            await repository.Create(dto);
        }

        [HttpDelete]
        public async Task Delete(ServiceDto req)
        {
            var dto = req.Adapt<Service>();

            await repository.Delete(dto);
        }

        [HttpPut]
        public async Task Update(ServiceDto req)
        {
            var dto = req.Adapt<Service>();

            await repository.Update(dto);
        }

        [HttpGet("ServiceGetById")]
        public async Task<ServiceDto> GetById(int id)
        {
            return (await repository.GetById(id)).Adapt<ServiceDto>();
        }

        [HttpGet("ServiceGetAll")]
        public async Task<List<ServiceDto>> GetAll()
        {
            var query = (await repository.GetAll()).AsQueryable();

            var queryDtos = query.ProjectToType<ServiceDto>();

            return queryDtos.ToList();
        }

        [HttpPost("ServiceGetPaginatedSorted")]
        public async Task<List<ServiceDto>> GetPaginated(PaginationSortingRequest paginationSortingRequest)
        {
            var query = (await repository.GetAll()).AsQueryable();

            query = query.ApplyFiltering(paginationSortingRequest.Filter);

            query = query.ApplySorting(paginationSortingRequest.SortBy, paginationSortingRequest.Ascending);

            query = query.ApplyPagination(paginationSortingRequest.PageIndex, paginationSortingRequest.PageSize);

            return query.ProjectToType<ServiceDto>().ToList();
        }
    }
}
