using Microsoft.EntityFrameworkCore;
using SkiResort.Domain.dbo;
using SkiResort.Infrastructure.Extensions;

namespace SkiResort.Infrastructure.Database;

public class SkiResortInternalContext : DbContext
{
    public SkiResortInternalContext(DbContextOptions<SkiResortInternalContext> options)
        : base(options)
    {

    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceOrder> ServiceOrders { get; set; }
    public DbSet<Slope> Slopes { get; set; }
    public DbSet<EquipmentRental> EquipmentRentals { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<SkiLesson> SkiLessons { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<WeatherReport> WeatherReports { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<ClientEventCountModel> ClientEventCounts { get; set; }
    public DbSet<InstructorLessonCountModel> InstructorLessonCounts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new Configurations.ClientConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.BookingConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.RoomConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.ServiceConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.ServiceOrderConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.SlopeConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.EquipmentRentalConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.InstructorConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.SkiLessonConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.EventConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.TicketConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.MaintenanceRequestConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.EquipmentConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.WeatherReportConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.UserConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.RoleConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.RoleConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.ClientEventCountsConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.InstructorLessonCountsConfiguration());

        modelBuilder.ConvertToSnakeCase();
    }
}