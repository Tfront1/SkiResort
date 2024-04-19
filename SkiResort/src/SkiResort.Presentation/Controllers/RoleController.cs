using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts.dboContracts.Role;
using SkiResort.Domain.dbo;

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
        public async Task<IActionResult> Create(CreateRoleDto createRoleDto)
        {
            var client = createRoleDto.Adapt<Role>();

            var newRole = (await repository.Create(client)).Adapt<CreateRoleDto>();

            return Created(
                nameof(newRole),
                newRole);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(RoleDto updateDeleteRoleDto)
        {
            var client = updateDeleteRoleDto.Adapt<Role>();

            await repository.Delete(client);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoleDto updateDeleteRoleDto)
        {
            var client = updateDeleteRoleDto.Adapt<Role>();

            var updatedRole = (await repository.Update(client)).Adapt<RoleDto>();

            return Ok(updatedRole);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = (await repository.GetById(id)).Adapt<RoleDto>();

            if (client is null)
            {
                return NoContent();
            }

            return Ok(client);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var clients = (await repository.GetAll()).AsQueryable();

            var clientDtos = clients.ProjectToType<RoleDto>();

            if (clientDtos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(clientDtos);
        }
    }
}
