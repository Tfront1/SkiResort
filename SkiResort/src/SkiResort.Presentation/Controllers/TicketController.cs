using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Contracts.dboContracts.Ticket;
using SkiResort.Domain.dbo;
using SkiResort.Presentation.Extensions;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, Ticket> repository;

        public TicketController(
            IEntityRepositoryBase<int, Ticket> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Create(CreateTicketDto req)
        {
            var dto = req.Adapt<Ticket>();

            await repository.Create(dto);
        }

        [HttpDelete]
        public async Task Delete(TicketDto req)
        {
            var dto = req.Adapt<Ticket>();

            await repository.Delete(dto);
        }

        [HttpPut]
        public async Task Update(TicketDto req)
        {
            var dto = req.Adapt<Ticket>();

            await repository.Update(dto);
        }

        [HttpGet("TicketGetById")]
        public async Task<TicketDto> GetById(int id)
        {
            return (await repository.GetById(id)).Adapt<TicketDto>();
        }

        [HttpGet("TicketGetAll")]
        public async Task<List<TicketDto>> GetAll()
        {
            var query = (await repository.GetAll()).AsQueryable();

            var queryDtos = query.ProjectToType<TicketDto>();

            return queryDtos.ToList();
        }

        [HttpPost("TicketGetPaginatedSorted")]
        public async Task<List<TicketDto>> GetPaginated(PaginationSortingRequest paginationSortingRequest)
        {
            var query = (await repository.GetAll()).AsQueryable();

            query = query.ApplyFiltering(paginationSortingRequest.Filter);

            query = query.ApplySorting(paginationSortingRequest.SortBy, paginationSortingRequest.Ascending);

            query = query.ApplyPagination(paginationSortingRequest.PageIndex, paginationSortingRequest.PageSize);

            return query.ProjectToType<TicketDto>().ToList();
        }
    }
}
