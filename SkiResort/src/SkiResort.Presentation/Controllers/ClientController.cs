using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Contracts.dboContracts.Client;
using SkiResort.Domain.dbo;
using SkiResort.Presentation.Extensions;
using System.Linq.Dynamic.Core;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, Client> repository;

        public ClientController(
            IEntityRepositoryBase<int, Client> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task Create(CreateClientDto req)
        {
            var dto = req.Adapt<Client>();

            await repository.Create(dto);
        }

        [HttpDelete]
        public async Task Delete(ClientDto req)
        {
            var dto = req.Adapt<Client>();

            await repository.Delete(dto);
        }

        [HttpPut]
        public async Task Update(ClientDto req)
        {
            var dto = req.Adapt<Client>();

            await repository.Update(dto);
        }

        [HttpGet("ClientGetById")]
        public async Task<ClientDto> GetById(int id)
        {
            return (await repository.GetById(id)).Adapt<ClientDto>();
        }

        [HttpGet("ClientGetAll")]
        public async Task<List<ClientDto>> GetAll()
        {
            var query = (await repository.GetAll()).AsQueryable();

            var queryDtos = query.ProjectToType<ClientDto>();

            return queryDtos.ToList();
        }

        [HttpPost("ClientGetPaginatedSorted")]
        public async Task<List<ClientDto>> GetPaginated(PaginationSortingRequest paginationSortingRequest)
        {
            var query = (await repository.GetAll()).AsQueryable();

            query = query.ApplyFiltering(paginationSortingRequest.Filter);

            query = query.ApplySorting(paginationSortingRequest.SortBy, paginationSortingRequest.Ascending);

            query = query.ApplyPagination(paginationSortingRequest.PageIndex, paginationSortingRequest.PageSize);

            return query.ProjectToType<ClientDto>().ToList();
        }
    }
}
