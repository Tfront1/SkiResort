using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Contracts.dboContracts.Room;
using SkiResort.Domain.dbo;
using SkiResort.Presentation.Extensions;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, Room> repository;

        public RoomController(
            IEntityRepositoryBase<int, Room> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Create(CreateRoomDto req)
        {
            var dto = req.Adapt<Room>();

            await repository.Create(dto);
        }

        [HttpDelete]
        public async Task Delete(RoomDto req)
        {
            var dto = req.Adapt<Room>();

            await repository.Delete(dto);
        }

        [HttpPut]
        public async Task Update(RoomDto req)
        {
            var dto = req.Adapt<Room>();

            await repository.Update(dto);
        }

        [HttpGet("RoomGetById")]
        public async Task<RoomDto> GetById(int id)
        {
            return (await repository.GetById(id)).Adapt<RoomDto>();
        }

        [HttpGet("RoomGetAll")]
        public async Task<List<RoomDto>> GetAll()
        {
            var query = (await repository.GetAll()).AsQueryable();

            var queryDtos = query.ProjectToType<RoomDto>();

            return queryDtos.ToList();
        }

        [HttpPost("RoomGetPaginatedSorted")]
        public async Task<List<RoomDto>> GetPaginated(PaginationSortingRequest paginationSortingRequest)
        {
            var query = (await repository.GetAll()).AsQueryable();

            query = query.ApplyFiltering(paginationSortingRequest.Filter);

            query = query.ApplySorting(paginationSortingRequest.SortBy, paginationSortingRequest.Ascending);

            query = query.ApplyPagination(paginationSortingRequest.PageIndex, paginationSortingRequest.PageSize);

            return query.ProjectToType<RoomDto>().ToList();
        }
    }
}
