using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Contracts.dboContracts.Instructor;
using SkiResort.Domain.dbo;
using SkiResort.Presentation.Extensions;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int,Instructor> repository;

        public InstructorController(
            IEntityRepositoryBase<int, Instructor> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Create(CreateInstructorDto req)
        {
            var dto = req.Adapt<Instructor>();

            await repository.Create(dto);
        }

        [HttpDelete]
        public async Task Delete(InstructorDto req)
        {
            var dto = req.Adapt<Instructor>();

            await repository.Delete(dto);
        }

        [HttpPut]
        public async Task Update(InstructorDto req)
        {
            var dto = req.Adapt<Instructor>();

            await repository.Update(dto);
        }

        [HttpGet("InstructorGetById")]
        public async Task<InstructorDto> GetById(int id)
        {
            return (await repository.GetById(id)).Adapt<InstructorDto>();
        }

        [HttpGet("InstructorGetAll")]
        public async Task<List<InstructorDto>> GetAll()
        {
            var query = (await repository.GetAll()).AsQueryable();

            var queryDtos = query.ProjectToType<InstructorDto>();

            return queryDtos.ToList();
        }

        [HttpPost("InstructorGetPaginatedSorted")]
        public async Task<List<InstructorDto>> GetPaginated(PaginationSortingRequest paginationSortingRequest)
        {
            var query = (await repository.GetAll()).AsQueryable();

            query = query.ApplyFiltering(paginationSortingRequest.Filter);

            query = query.ApplySorting(paginationSortingRequest.SortBy, paginationSortingRequest.Ascending);

            query = query.ApplyPagination(paginationSortingRequest.PageIndex, paginationSortingRequest.PageSize);

            return query.ProjectToType<InstructorDto>().ToList();
        }
    }
}
