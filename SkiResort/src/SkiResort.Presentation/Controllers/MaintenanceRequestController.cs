using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Contracts.dboContracts.MaintenanceRequest;
using SkiResort.Domain.dbo;
using SkiResort.Presentation.Extensions;

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
        public async Task Create(CreateMaintenanceRequestDto req)
        {
            var dto = req.Adapt<MaintenanceRequest>();

            await repository.Create(dto);
        }

        [HttpDelete]
        public async Task Delete(MaintenanceRequestDto req)
        {
            var dto = req.Adapt<MaintenanceRequest>();

            await repository.Delete(dto);
        }

        [HttpPut]
        public async Task Update(MaintenanceRequestDto req)
        {
            var dto = req.Adapt<MaintenanceRequest>();

            await repository.Update(dto);
        }

        [HttpGet("MaintenanceRequestGetById")]
        public async Task<MaintenanceRequestDto> GetById(int id)
        {
            return (await repository.GetById(id)).Adapt<MaintenanceRequestDto>();
        }

        [HttpGet("MaintenanceRequestGetAll")]
        public async Task<List<MaintenanceRequestDto>> GetAll()
        {
            var query = (await repository.GetAll()).AsQueryable();

            var queryDtos = query.ProjectToType<MaintenanceRequestDto>();

            return queryDtos.ToList();
        }

        [HttpPost("MaintenanceRequestGetPaginatedSorted")]
        public async Task<List<MaintenanceRequestDto>> GetPaginated(PaginationSortingRequest paginationSortingRequest)
        {
            var query = (await repository.GetAll()).AsQueryable();

            query = query.ApplyFiltering(paginationSortingRequest.Filter);

            query = query.ApplySorting(paginationSortingRequest.SortBy, paginationSortingRequest.Ascending);

            query = query.ApplyPagination(paginationSortingRequest.PageIndex, paginationSortingRequest.PageSize);

            return query.ProjectToType<MaintenanceRequestDto>().ToList();
        }
    }
}
