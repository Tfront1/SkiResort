using Mapster;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Contracts.dboContracts.Booking;
using SkiResort.Domain.dbo;
using SkiResort.Presentation.Extensions;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, Booking> repository;

        public BookingController(
            IEntityRepositoryBase<int, Booking> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Create(CreateBookingDto req)
        {
            var dto = req.Adapt<Booking>();

            await repository.Create(dto);
        }

        [HttpDelete]
        public async Task Delete(BookingDto req)
        {
            var dto = req.Adapt<Booking>();

            await repository.Delete(dto);
        }

        [HttpPut]
        public async Task Update(BookingDto req)
        {
            var dto = req.Adapt<Booking>();

            await repository.Update(dto);
        }

        [HttpGet("BookingGetById")]
        public async Task<BookingDto> GetById(int id)
        {
            return (await repository.GetById(id)).Adapt<BookingDto>();
        }

        [HttpGet("BookingGetAll")]
        public async Task<List<BookingDto>> GetAll()
        {
            var query = (await repository.GetAll()).AsQueryable();

            var queryDtos = query.ProjectToType<BookingDto>();

            return queryDtos.ToList();
        }

        [HttpPost("BookingGetPaginatedSorted")]
        public async Task<List<BookingDto>> GetPaginated(PaginationSortingRequest paginationSortingRequest)
        {
            var query = (await repository.GetAll()).AsQueryable();

            query = query.ApplyFiltering(paginationSortingRequest.Filter);

            query = query.ApplySorting(paginationSortingRequest.SortBy, paginationSortingRequest.Ascending);

            query = query.ApplyPagination(paginationSortingRequest.PageIndex, paginationSortingRequest.PageSize);

            return query.ProjectToType<BookingDto>().ToList();
        }
    }
}
