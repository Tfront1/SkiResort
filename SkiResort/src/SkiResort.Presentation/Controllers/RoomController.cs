using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts.dboContracts.Room;
using SkiResort.Domain.dbo;

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
        public async Task<IActionResult> Create(CreateRoomDto createRoomDto)
        {
            var client = createRoomDto.Adapt<Room>();

            var newRoom = (await repository.Create(client)).Adapt<CreateRoomDto>();

            return Created(
                nameof(newRoom),
                newRoom);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(RoomDto updateDeleteRoomDto)
        {
            var client = updateDeleteRoomDto.Adapt<Room>();

            await repository.Delete(client);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoomDto updateDeleteRoomDto)
        {
            var client = updateDeleteRoomDto.Adapt<Room>();

            var updatedRoom = (await repository.Update(client)).Adapt<RoomDto>();

            return Ok(updatedRoom);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = (await repository.GetById(id)).Adapt<RoomDto>();

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

            var clientDtos = clients.ProjectToType<RoomDto>();

            if (clientDtos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(clientDtos);
        }
    }
}
