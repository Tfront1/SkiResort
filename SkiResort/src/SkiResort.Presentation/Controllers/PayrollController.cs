using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Contracts.dboContracts.Payroll;
using SkiResort.Domain.dbo;
using SkiResort.Presentation.Extensions;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, Payroll> repository;

        public PayrollController(
            IEntityRepositoryBase<int, Payroll> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Create(CreatePayrollDto req)
        {
            var dto = req.Adapt<Payroll>();

            await repository.Create(dto);
        }

        [HttpDelete]
        public async Task Delete(PayrollDto req)
        {
            var dto = req.Adapt<Payroll>();

            await repository.Delete(dto);
        }

        [HttpPut]
        public async Task Update(PayrollDto req)
        {
            var dto = req.Adapt<Payroll>();

            await repository.Update(dto);
        }

        [HttpGet("PayrollGetById")]
        public async Task<PayrollDto> GetById(int id)
        {
            return (await repository.GetById(id)).Adapt<PayrollDto>();
        }

        [HttpGet("PayrollGetAll")]
        public async Task<List<PayrollDto>> GetAll()
        {
            var query = (await repository.GetAll()).AsQueryable();

            var queryDtos = query.ProjectToType<PayrollDto>();

            return queryDtos.ToList();
        }

        [HttpPost("PayrollGetPaginatedSorted")]
        public async Task<List<PayrollDto>> GetPaginated(PaginationSortingRequest paginationSortingRequest)
        {
            var query = (await repository.GetAll()).AsQueryable();

            query = query.ApplyFiltering(paginationSortingRequest.Filter);

            query = query.ApplySorting(paginationSortingRequest.SortBy, paginationSortingRequest.Ascending);

            query = query.ApplyPagination(paginationSortingRequest.PageIndex, paginationSortingRequest.PageSize);

            return query.ProjectToType<PayrollDto>().ToList();
        }
    }
}
