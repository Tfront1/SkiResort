using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkiResort.Application.Repositories;
using SkiResort.Contracts;
using SkiResort.Domain.dbo;
using SkiResort.Infrastructure.Database;
using SkiResort.Presentation.Extensions;

namespace SkiResort.Presentation.Controllers
{
    public class ClientEventCountController : Controller
    {
        protected readonly SkiResortInternalContext context;

        public ClientEventCountController(
            SkiResortInternalContext context)
        {
            this.context = context;
        }

        [HttpGet("ClientEventCountGetAll")]
        public async Task<List<ClientEventCountModel>> GetAll()
        {
            return context.ClientEventCounts.ToList();
        }
    }
}
