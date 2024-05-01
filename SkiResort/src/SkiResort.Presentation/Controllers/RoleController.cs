using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Contracts.dboContracts.Role;
using SkiResort.Domain.dbo;
using SkiResort.Presentation.Extensions;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, Role> repository;

        public RoleController(
            IEntityRepositoryBase<int, Role> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Create(CreateRoleDto req)
        {
            var dto = req.Adapt<Role>();

            await repository.Create(dto);
        }

        [HttpDelete]
        public async Task Delete(RoleDto req)
        {
            var dto = req.Adapt<Role>();

            await repository.Delete(dto);
        }

        [HttpPut]
        public async Task Update(RoleDto req)
        {
            var dto = req.Adapt<Role>();

            await repository.Update(dto);
        }

        [HttpGet("RoleGetById")]
        public async Task<RoleDto> GetById(int id)
        {
            return (await repository.GetById(id)).Adapt<RoleDto>();
        }

        [HttpGet("RoleGetAll")]
        public async Task<List<RoleDto>> GetAll()
        {
            var query = (await repository.GetAll()).AsQueryable();

            var queryDtos = query.ProjectToType<RoleDto>();

            return queryDtos.ToList();
        }

        [HttpPost("RoleGetPaginatedSorted")]
        public async Task<List<RoleDto>> GetPaginated(PaginationSortingRequest paginationSortingRequest)
        {
            var query = (await repository.GetAll()).AsQueryable();

            query = query.ApplyFiltering(paginationSortingRequest.Filter);

            query = query.ApplySorting(paginationSortingRequest.SortBy, paginationSortingRequest.Ascending);

            query = query.ApplyPagination(paginationSortingRequest.PageIndex, paginationSortingRequest.PageSize);

            return query.ProjectToType<RoleDto>().ToList();
        }
    }
}
