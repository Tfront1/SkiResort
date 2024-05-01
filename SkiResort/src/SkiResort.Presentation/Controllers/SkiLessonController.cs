using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Contracts.dboContracts.SkiLesson;
using SkiResort.Domain.dbo;
using SkiResort.Presentation.Extensions;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkiLessonController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, SkiLesson> repository;

        public SkiLessonController(
            IEntityRepositoryBase<int, SkiLesson> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Create(CreateSkiLessonDto req)
        {
            var dto = req.Adapt<SkiLesson>();

            await repository.Create(dto);
        }

        [HttpDelete]
        public async Task Delete(SkiLessonDto req)
        {
            var dto = req.Adapt<SkiLesson>();

            await repository.Delete(dto);
        }

        [HttpPut]
        public async Task Update(SkiLessonDto req)
        {
            var dto = req.Adapt<SkiLesson>();

            await repository.Update(dto);
        }

        [HttpGet("SkiLessonGetById")]
        public async Task<SkiLessonDto> GetById(int id)
        {
            return (await repository.GetById(id)).Adapt<SkiLessonDto>();
        }

        [HttpGet("SkiLessonGetAll")]
        public async Task<List<SkiLessonDto>> GetAll()
        {
            var query = (await repository.GetAll()).AsQueryable();

            var queryDtos = query.ProjectToType<SkiLessonDto>();

            return queryDtos.ToList();
        }

        [HttpPost("SkiLessonGetPaginatedSorted")]
        public async Task<List<SkiLessonDto>> GetPaginated(PaginationSortingRequest paginationSortingRequest)
        {
            var query = (await repository.GetAll()).AsQueryable();

            query = query.ApplyFiltering(paginationSortingRequest.Filter);

            query = query.ApplySorting(paginationSortingRequest.SortBy, paginationSortingRequest.Ascending);

            query = query.ApplyPagination(paginationSortingRequest.PageIndex, paginationSortingRequest.PageSize);

            return query.ProjectToType<SkiLessonDto>().ToList();
        }
    }
}
