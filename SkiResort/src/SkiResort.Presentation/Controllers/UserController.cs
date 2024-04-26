using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts.dboContracts.User;
using SkiResort.Domain.dbo;

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
        public async Task<IActionResult> Create(CreateUserDto createUserDto)
        {
            var client = createUserDto.Adapt<User>();

            var newUser = (await repository.Create(client)).Adapt<CreateUserDto>();

            return Created(
                nameof(newUser),
                newUser);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(UserDto updateDeleteUserDto)
        {
            var client = updateDeleteUserDto.Adapt<User>();

            await repository.Delete(client);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDto updateDeleteUserDto)
        {
            var client = updateDeleteUserDto.Adapt<User>();

            var updatedUser = (await repository.Update(client)).Adapt<UserDto>();

            return Ok(updatedUser);
        }

        [HttpGet("UserGetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = (await repository.GetById(id)).Adapt<UserDto>();

            if (client is null)
            {
                return NoContent();
            }

            return Ok(client);
        }

        [HttpGet("UserGetAll")]
        public async Task<IActionResult> GetAll()
        {
            var clients = (await repository.GetAll()).AsQueryable();

            var clientDtos = clients.ProjectToType<UserDto>();

            if (clientDtos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(clientDtos);
        }
    }
}
