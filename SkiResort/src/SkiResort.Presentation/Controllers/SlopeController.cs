using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Contracts.dboContracts.Slope;
using SkiResort.Domain.dbo;
using SkiResort.Presentation.Extensions;

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
        public async Task Create(CreateSlopeDto req)
        {
            var dto = req.Adapt<Slope>();

            await repository.Create(dto);
        }

        [HttpDelete]
        public async Task Delete(SlopeDto req)
        {
            var dto = req.Adapt<Slope>();

            await repository.Delete(dto);
        }

        [HttpPut]
        public async Task Update(SlopeDto req)
        {
            var dto = req.Adapt<Slope>();

            await repository.Update(dto);
        }

        [HttpGet("SlopeGetById")]
        public async Task<SlopeDto> GetById(int id)
        {
            return (await repository.GetById(id)).Adapt<SlopeDto>();
        }

        [HttpGet("SlopeGetAll")]
        public async Task<List<SlopeDto>> GetAll()
        {
            var query = (await repository.GetAll()).AsQueryable();

            var queryDtos = query.ProjectToType<SlopeDto>();

            return queryDtos.ToList();
        }

        [HttpPost("SlopeGetPaginatedSorted")]
        public async Task<List<SlopeDto>> GetPaginated(PaginationSortingRequest paginationSortingRequest)
        {
            var query = (await repository.GetAll()).AsQueryable();

            query = query.ApplyFiltering(paginationSortingRequest.Filter);

            query = query.ApplySorting(paginationSortingRequest.SortBy, paginationSortingRequest.Ascending);

            query = query.ApplyPagination(paginationSortingRequest.PageIndex, paginationSortingRequest.PageSize);

            return query.ProjectToType<SlopeDto>().ToList();
        }
    }
}
