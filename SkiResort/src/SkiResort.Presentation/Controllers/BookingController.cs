using Mapster;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts.dboContracts.Booking;
using SkiResort.Domain.dbo;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, Booking> repository;

        public BookingController(
            IEntityRepositoryBase<int, Booking> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingDto createBookingDto)
        {
            var client = createBookingDto.Adapt<Booking>();

            var newBooking = (await repository.Create(client)).Adapt<CreateBookingDto>();

            return Created(
                nameof(newBooking),
                newBooking);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(BookingDto updateDeleteBookingDto)
        {
            var client = updateDeleteBookingDto.Adapt<Booking>();

            await repository.Delete(client);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(BookingDto updateDeleteBookingDto)
        {
            var client = updateDeleteBookingDto.Adapt<Booking>();

            var updatedBooking = (await repository.Update(client)).Adapt<BookingDto>();

            return Ok(updatedBooking);
        }

        [HttpGet("BookingGetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = (await repository.GetById(id)).Adapt<BookingDto>();

            if (client is null)
            {
                return NoContent();
            }

            return Ok(client);
        }

        [HttpGet("BookingGetAll")]
        public async Task<IActionResult> GetAll()
        {
            var clients = (await repository.GetAll()).AsQueryable();

            var clientDtos = clients.ProjectToType<BookingDto>();

            if (clientDtos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(clientDtos);
        }
    }
}
