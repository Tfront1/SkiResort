using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Contracts.dboContracts.User;
using SkiResort.Domain.dbo;
using SkiResort.Presentation.Extensions;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, User> repository;

        public UserController(
            IEntityRepositoryBase<int, User> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Create(CreateUserDto req)
        {
            var dto = req.Adapt<User>();

            await repository.Create(dto);
        }

        [HttpDelete]
        public async Task Delete(UserDto req)
        {
            var dto = req.Adapt<User>();

            await repository.Delete(dto);
        }

        [HttpPut]
        public async Task Update(UserDto req)
        {
            var dto = req.Adapt<User>();

            await repository.Update(dto);
        }

        [HttpGet("UserGetById")]
        public async Task<UserDto> GetById(int id)
        {
            return (await repository.GetById(id)).Adapt<UserDto>();
        }

        [HttpGet("UserGetAll")]
        public async Task<List<UserDto>> GetAll()
        {
            var query = (await repository.GetAll()).AsQueryable();

            var queryDtos = query.ProjectToType<UserDto>();

            return queryDtos.ToList();
        }

        [HttpPost("UserGetPaginatedSorted")]
        public async Task<List<UserDto>> GetPaginated(PaginationSortingRequest paginationSortingRequest)
        {
            var query = (await repository.GetAll()).AsQueryable();

            query = query.ApplyFiltering(paginationSortingRequest.Filter);

            query = query.ApplySorting(paginationSortingRequest.SortBy, paginationSortingRequest.Ascending);

            query = query.ApplyPagination(paginationSortingRequest.PageIndex, paginationSortingRequest.PageSize);

            return query.ProjectToType<UserDto>().ToList();
        }
    }
}
