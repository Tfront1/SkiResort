using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Contracts.dboContracts.EquipmentRental;
using SkiResort.Domain.dbo;
using SkiResort.Presentation.Extensions;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentRentalController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, EquipmentRental> repository;

        public EquipmentRentalController(
            IEntityRepositoryBase<int, EquipmentRental> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Create(CreateEquipmentRentalDto req)
        {
            var dto = req.Adapt<EquipmentRental>();

            await repository.Create(dto);
        }

        [HttpDelete]
        public async Task Delete(EquipmentRentalDto req)
        {
            var dto = req.Adapt<EquipmentRental>();

            await repository.Delete(dto);
        }

        [HttpPut]
        public async Task Update(EquipmentRentalDto req)
        {
            var dto = req.Adapt<EquipmentRental>();

            await repository.Update(dto);
        }

        [HttpGet("EquipmentRentalGetById")]
        public async Task<EquipmentRentalDto> GetById(int id)
        {
            return (await repository.GetById(id)).Adapt<EquipmentRentalDto>();
        }

        [HttpGet("EquipmentRentalGetAll")]
        public async Task<List<EquipmentRentalDto>> GetAll()
        {
            var query = (await repository.GetAll()).AsQueryable();

            var queryDtos = query.ProjectToType<EquipmentRentalDto>();

            return queryDtos.ToList();
        }

        [HttpPost("EquipmentRentalGetPaginatedSorted")]
        public async Task<List<EquipmentRentalDto>> GetPaginated(PaginationSortingRequest paginationSortingRequest)
        {
            var query = (await repository.GetAll()).AsQueryable();

            query = query.ApplyFiltering(paginationSortingRequest.Filter);

            query = query.ApplySorting(paginationSortingRequest.SortBy, paginationSortingRequest.Ascending);

            query = query.ApplyPagination(paginationSortingRequest.PageIndex, paginationSortingRequest.PageSize);

            return query.ProjectToType<EquipmentRentalDto>().ToList();
        }
    }
}
