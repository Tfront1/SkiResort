using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Contracts.dboContracts.Event;
using SkiResort.Domain.dbo;
using SkiResort.Presentation.Extensions;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, Event> repository;

        public EventController(
            IEntityRepositoryBase<int, Event> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Create(CreateEventDto req)
        {
            var dto = req.Adapt<Event>();

            await repository.Create(dto);
        }

        [HttpDelete]
        public async Task Delete(EventDto req)
        {
            var dto = req.Adapt<Event>();

            await repository.Delete(dto);
        }

        [HttpPut]
        public async Task Update(EventDto req)
        {
            var dto = req.Adapt<Event>();

            await repository.Update(dto);
        }

        [HttpGet("EventGetById")]
        public async Task<EventDto> GetById(int id)
        {
            return (await repository.GetById(id)).Adapt<EventDto>();
        }

        [HttpGet("EventGetAll")]
        public async Task<List<EventDto>> GetAll()
        {
            var query = (await repository.GetAll()).AsQueryable();

            var queryDtos = query.ProjectToType<EventDto>();

            return queryDtos.ToList();
        }

        [HttpPost("EventGetPaginatedSorted")]
        public async Task<List<EventDto>> GetPaginated(PaginationSortingRequest paginationSortingRequest)
        {
            var query = (await repository.GetAll()).AsQueryable();

            query = query.ApplyFiltering(paginationSortingRequest.Filter);

            query = query.ApplySorting(paginationSortingRequest.SortBy, paginationSortingRequest.Ascending);

            query = query.ApplyPagination(paginationSortingRequest.PageIndex, paginationSortingRequest.PageSize);

            return query.ProjectToType<EventDto>().ToList();
        }
    }
}
