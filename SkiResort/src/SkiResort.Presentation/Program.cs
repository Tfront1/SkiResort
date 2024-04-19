using Mapster;
using Microsoft.EntityFrameworkCore;
using SkiResort.Application.Repositories;
using SkiResort.Infrastructure.Database;
using SkiResort.Infrastructure.Repositories;

namespace SkiResort.Presentation;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
       
        builder.Services.AddDbContext<SkiResortInternalContext>(options =>
            options.UseNpgsql(connectionString));

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddTransient(typeof(IEntityRepositoryBase<,>), typeof(EntityRepositoryBase<,>));

        builder.Services.AddMapster();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
