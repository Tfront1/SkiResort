using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Contracts.dboContracts.Equipment;
using SkiResort.Domain.dbo;
using SkiResort.Presentation.Extensions;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, Equipment> repository;

        public EquipmentController(
            IEntityRepositoryBase<int, Equipment> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Create(CreateEquipmentDto req)
        {
            var dto = req.Adapt<Equipment>();

            await repository.Create(dto);
        }

        [HttpDelete]
        public async Task Delete(EquipmentDto req)
        {
            var dto = req.Adapt<Equipment>();

            await repository.Delete(dto);
        }

        [HttpPut]
        public async Task Update(EquipmentDto req)
        {
            var dto = req.Adapt<Equipment>();

            await repository.Update(dto);
        }

        [HttpGet("EquipmentGetById")]
        public async Task<EquipmentDto> GetById(int id)
        {
            return (await repository.GetById(id)).Adapt<EquipmentDto>();
        }

        [HttpGet("EquipmentGetAll")]
        public async Task<List<EquipmentDto>> GetAll()
        {
            var query = (await repository.GetAll()).AsQueryable();

            var queryDtos = query.ProjectToType<EquipmentDto>();

            return queryDtos.ToList();
        }

        [HttpPost("EquipmentGetPaginatedSorted")]
        public async Task<List<EquipmentDto>> GetPaginated(PaginationSortingRequest paginationSortingRequest)
        {
            var query = (await repository.GetAll()).AsQueryable();

            query = query.ApplyFiltering(paginationSortingRequest.Filter);

            query = query.ApplySorting(paginationSortingRequest.SortBy, paginationSortingRequest.Ascending);

            query = query.ApplyPagination(paginationSortingRequest.PageIndex, paginationSortingRequest.PageSize);

            return query.ProjectToType<EquipmentDto>().ToList();
        }
    }
}
