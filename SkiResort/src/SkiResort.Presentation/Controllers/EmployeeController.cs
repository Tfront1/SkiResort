using Mapster;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts.dboContracts.Employee;
using SkiResort.Domain.dbo;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, Employee> repository;

        public EmployeeController(
            IEntityRepositoryBase<int, Employee> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeDto createEmployeeDto)
        {
            var client = createEmployeeDto.Adapt<Employee>();

            var newEmployee = (await repository.Create(client)).Adapt<CreateEmployeeDto>();

            return Created(
                nameof(newEmployee),
                newEmployee);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(EmployeeDto updateDeleteEmployeeDto)
        {
            var client = updateDeleteEmployeeDto.Adapt<Employee>();

            await repository.Delete(client);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(EmployeeDto updateDeleteEmployeeDto)
        {
            var client = updateDeleteEmployeeDto.Adapt<Employee>();

            var updatedEmployee = (await repository.Update(client)).Adapt<EmployeeDto>();

            return Ok(updatedEmployee);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = (await repository.GetById(id)).Adapt<EmployeeDto>();

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

            var clientDtos = clients.ProjectToType<EmployeeDto>();

            if (clientDtos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(clientDtos);
        }
    }
}
