using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Contracts.dboContracts.ServiceOrder;
using SkiResort.Domain.dbo;
using SkiResort.Presentation.Extensions;

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
        public async Task Create(CreateServiceOrderDto req)
        {
            var dto = req.Adapt<ServiceOrder>();

            await repository.Create(dto);
        }

        [HttpDelete]
        public async Task Delete(ServiceOrderDto req)
        {
            var dto = req.Adapt<ServiceOrder>();

            await repository.Delete(dto);
        }

        [HttpPut]
        public async Task Update(ServiceOrderDto req)
        {
            var dto = req.Adapt<ServiceOrder>();

            await repository.Update(dto);
        }

        [HttpGet("ServiceOrderGetById")]
        public async Task<ServiceOrderDto> GetById(int id)
        {
            return (await repository.GetById(id)).Adapt<ServiceOrderDto>();
        }

        [HttpGet("ServiceOrderGetAll")]
        public async Task<List<ServiceOrderDto>> GetAll()
        {
            var query = (await repository.GetAll()).AsQueryable();

            var queryDtos = query.ProjectToType<ServiceOrderDto>();

            return queryDtos.ToList();
        }

        [HttpPost("ServiceOrderGetPaginatedSorted")]
        public async Task<List<ServiceOrderDto>> GetPaginated(PaginationSortingRequest paginationSortingRequest)
        {
            var query = (await repository.GetAll()).AsQueryable();

            query = query.ApplyFiltering(paginationSortingRequest.Filter);

            query = query.ApplySorting(paginationSortingRequest.SortBy, paginationSortingRequest.Ascending);

            query = query.ApplyPagination(paginationSortingRequest.PageIndex, paginationSortingRequest.PageSize);

            return query.ProjectToType<ServiceOrderDto>().ToList();
        }
    }
}
