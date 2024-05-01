using Mapster;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Contracts.dboContracts.Employee;
using SkiResort.Domain.dbo;
using SkiResort.Presentation.Extensions;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, Employee> repository;

        public EmployeeController(
            IEntityRepositoryBase<int, Employee> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Create(CreateEmployeeDto req)
        {
            var dto = req.Adapt<Employee>();

            await repository.Create(dto);
        }

        [HttpDelete]
        public async Task Delete(EmployeeDto req)
        {
            var dto = req.Adapt<Employee>();

            await repository.Delete(dto);
        }

        [HttpPut]
        public async Task Update(EmployeeDto req)
        {
            var dto = req.Adapt<Employee>();

            await repository.Update(dto);
        }

        [HttpGet("EmployeeGetById")]
        public async Task<EmployeeDto> GetById(int id)
        {
            return (await repository.GetById(id)).Adapt<EmployeeDto>();
        }

        [HttpGet("EmployeeGetAll")]
        public async Task<List<EmployeeDto>> GetAll()
        {
            var query = (await repository.GetAll()).AsQueryable();

            var queryDtos = query.ProjectToType<EmployeeDto>();

            return queryDtos.ToList();
        }

        [HttpPost("EmployeeGetPaginatedSorted")]
        public async Task<List<EmployeeDto>> GetPaginated(PaginationSortingRequest paginationSortingRequest)
        {
            var query = (await repository.GetAll()).AsQueryable();

            query = query.ApplyFiltering(paginationSortingRequest.Filter);

            query = query.ApplySorting(paginationSortingRequest.SortBy, paginationSortingRequest.Ascending);

            query = query.ApplyPagination(paginationSortingRequest.PageIndex, paginationSortingRequest.PageSize);

            return query.ProjectToType<EmployeeDto>().ToList();
        }
    }
}
