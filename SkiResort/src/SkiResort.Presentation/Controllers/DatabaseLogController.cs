using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Domain.dbo;
using SkiResort.Presentation.Extensions;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseLogController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, DatabaseLogModel> repository;

        public DatabaseLogController(
            IEntityRepositoryBase<int, DatabaseLogModel> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost("DatabaseLogGetPaginatedSorted")]
        public async Task<List<DatabaseLogModel>> GetPaginated(PaginationSortingRequest paginationSortingRequest)
        {
            var query = (await repository.GetAll()).AsQueryable();

            query = query.ApplyFiltering(paginationSortingRequest.Filter);

            query = query.ApplySorting(paginationSortingRequest.SortBy, paginationSortingRequest.Ascending);

            query = query.ApplyPagination(paginationSortingRequest.PageIndex, paginationSortingRequest.PageSize);

            return query.ToList();
        }
    }
}
