using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts.dboContracts.Payroll;
using SkiResort.Domain.dbo;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, Payroll> repository;

        public PayrollController(
            IEntityRepositoryBase<int, Payroll> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePayrollDto createPayrollDto)
        {
            var client = createPayrollDto.Adapt<Payroll>();

            var newPayroll = (await repository.Create(client)).Adapt<CreatePayrollDto>();

            return Created(
                nameof(newPayroll),
                newPayroll);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(PayrollDto updateDeletePayrollDto)
        {
            var client = updateDeletePayrollDto.Adapt<Payroll>();

            await repository.Delete(client);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(PayrollDto updateDeletePayrollDto)
        {
            var client = updateDeletePayrollDto.Adapt<Payroll>();

            var updatedPayroll = (await repository.Update(client)).Adapt<PayrollDto>();

            return Ok(updatedPayroll);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = (await repository.GetById(id)).Adapt<PayrollDto>();

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

            var clientDtos = clients.ProjectToType<PayrollDto>();

            if (clientDtos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(clientDtos);
        }
    }
}
