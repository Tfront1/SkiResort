using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Application.Repositories;
using SkiResort.Contracts.dboContracts.Booking;
using SkiResort.Contracts.dboContracts.Client;
using SkiResort.Contracts.dboContracts.Equipment;
using SkiResort.Contracts.dboContracts.EquipmentRental;
using SkiResort.Contracts.dboContracts.Event;
using SkiResort.Contracts.dboContracts.Instructor;
using SkiResort.Contracts.dboContracts.MaintenanceRequest;
using SkiResort.Contracts.dboContracts.Room;
using SkiResort.Contracts.dboContracts.Service;
using SkiResort.Contracts.dboContracts.ServiceOrder;
using SkiResort.Contracts.dboContracts.SkiLesson;
using SkiResort.Contracts.dboContracts.Slope;
using SkiResort.Contracts.dboContracts.Ticket;
using SkiResort.Contracts.dboContracts.WeatherReport;
using SkiResort.Domain.dbo;

namespace SkiResort.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly IEntityRepositoryBase<int, Client> clientRepository;
        private readonly IEntityRepositoryBase<int, Event> eventRepository;
        private readonly IEntityRepositoryBase<int, Instructor> instructorRepository;
        private readonly IEntityRepositoryBase<int, SkiLesson> skiLessonRepository;
        private readonly IEntityRepositoryBase<int, Ticket> ticketRepository;
        private readonly IEntityRepositoryBase<int, Slope> slopeRepository;
        private readonly IEntityRepositoryBase<int, WeatherReport> weatherRepository;
        private readonly IEntityRepositoryBase<int, Service> serviceRepository;
        private readonly IEntityRepositoryBase<int, ServiceOrder> serviceOrderRepository;
        private readonly IEntityRepositoryBase<int, Room> roomRepository;
        private readonly IEntityRepositoryBase<int, Booking> bookingRepository;
        private readonly IEntityRepositoryBase<int, Equipment> equipmentRepository;
        private readonly IEntityRepositoryBase<int, MaintenanceRequest> maintenanceRequestRepository;
        private readonly IEntityRepositoryBase<int, EquipmentRental> equipmentRentalRepository;
        public SeedController(
            IEntityRepositoryBase<int, Client> clientRepository,
            IEntityRepositoryBase<int, Event> eventRepository,
            IEntityRepositoryBase<int, Instructor> instructorRepository,
            IEntityRepositoryBase<int, SkiLesson> skiLessonRepository,
            IEntityRepositoryBase<int, Ticket> ticketRepository,
            IEntityRepositoryBase<int, Slope> slopeRepository,
            IEntityRepositoryBase<int, WeatherReport> weatherRepository,
            IEntityRepositoryBase<int, Service> serviceRepository,
            IEntityRepositoryBase<int, ServiceOrder> serviceOrderRepository,
            IEntityRepositoryBase<int, Room> roomRepository,
            IEntityRepositoryBase<int, Booking> bookingRepository,
            IEntityRepositoryBase<int, Equipment> equipmentRepository,
            IEntityRepositoryBase<int, EquipmentRental> equipmentRentalRepository,
            IEntityRepositoryBase<int, MaintenanceRequest> maintenanceRequestRepository)
        {
            this.clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            this.eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            this.instructorRepository = instructorRepository ?? throw new ArgumentNullException(nameof(instructorRepository));
            this.skiLessonRepository = skiLessonRepository ?? throw new ArgumentNullException(nameof(skiLessonRepository));
            this.ticketRepository = ticketRepository ?? throw new ArgumentNullException(nameof(ticketRepository));
            this.slopeRepository = slopeRepository ?? throw new ArgumentNullException(nameof(slopeRepository));
            this.weatherRepository = weatherRepository ?? throw new ArgumentNullException(nameof(weatherRepository));
            this.serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
            this.serviceOrderRepository = serviceOrderRepository ?? throw new ArgumentNullException(nameof(serviceOrderRepository));
            this.roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
            this.bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
            this.equipmentRepository = equipmentRepository ?? throw new ArgumentNullException(nameof(equipmentRepository));
            this.equipmentRentalRepository = equipmentRentalRepository ?? throw new ArgumentNullException(nameof(equipmentRentalRepository));
            this.maintenanceRequestRepository = maintenanceRequestRepository ?? throw new ArgumentNullException(nameof(maintenanceRequestRepository));
        }

        [HttpPost("Seed")]
        public async Task Seed(int coef)
        {
            //Add clients
            var clientDto = new List<CreateClientDto>();
            for (int i = 0; i < coef; i++)
            {
                clientDto.Add(new CreateClientDto
                {
                    FirstName = $"FirstName{i}",
                    LastName = $"LastName{i}",
                    Email = $"email{i}@example.com",
                    Phone = $"123456789{i % 10}"
                });
            }
            var clientsList = clientDto.AsQueryable().ProjectToType<Client>().ToList();
            await clientRepository.BulkCreate(clientsList);

            //Add events
            var random = new Random();
            var today = DateTime.Today;
            var start = new DateTime(today.Year, today.Month, 1).AddMonths(1); // Перший день наступного місяця
            var endRange = start.AddMonths(1).AddDays(-1);
            var eventDto = new List<CreateEventDto>();
            for (int i = 0; i < coef * 2; i++)
            {
                eventDto.Add(new CreateEventDto
                {
                    Name = $"EventName{i}",
                    StartDate = start.AddDays(random.Next((endRange - start).Days)).ToUniversalTime(),
                    EndDate = start.AddDays(random.Next((endRange - start).Days)).ToUniversalTime(),
                    Location = $"Location{i}"
                });
            }

            var eventsList = eventDto.AsQueryable().ProjectToType<Event>().ToList();

            await eventRepository.BulkCreate(eventsList);

            //Add instructors
            var instructorDto = new List<CreateInstructorDto>();
            for (int i = 0; i < coef * 2; i++)
            {
                instructorDto.Add(new CreateInstructorDto
                {
                    FirstName = $"InstructoreName{i}",
                    LastName = $"InstructoreSureName{i}",
                    Specialization = $"InstructoreSpecialization{i}",
                });
            }

            var instructorList = instructorDto.AsQueryable().ProjectToType<Instructor>().ToList();

            await instructorRepository.BulkCreate(instructorList);

            //Add SkiLessons
            var skiLessonsDto = new List<CreateSkiLessonDto>();

            for (int i = 0; i < clientsList.Count(); i++)
            {
                if (i % 2 == 0)
                {
                    skiLessonsDto.Add(new CreateSkiLessonDto
                    {
                        InstructorId = instructorList[i].Id,
                        ClientId = clientsList[i].Id,
                        StartDate = start.AddDays(random.Next((endRange - start).Days)).ToUniversalTime(),
                        Duration = new TimeSpan(hours: random.Next(1, 10), minutes: 0, seconds: 0),
                    });
                }
                else 
                {
                    skiLessonsDto.Add(new CreateSkiLessonDto
                    {
                        InstructorId = instructorList[i].Id,
                        ClientId = clientsList[i-1].Id,
                        StartDate = start.AddDays(random.Next((endRange - start).Days)).ToUniversalTime(),
                        Duration = new TimeSpan(hours: random.Next(1, 10), minutes: 0, seconds: 0),
                    });
                }
                
            }

            var skiLessonsList = skiLessonsDto.AsQueryable().ProjectToType<SkiLesson>().ToList();

            await skiLessonRepository.BulkCreate(skiLessonsList);

            //Add Tickets
            var ticketDto = new List<CreateTicketDto>();

            for (int i = 0; i < clientsList.Count(); i++)
            {
                if (i % 2 == 0)
                {
                    ticketDto.Add(new CreateTicketDto
                    {
                        EventId = instructorList[i].Id,
                        ClientId = clientsList[i].Id,
                        PurchaseDate = start.AddDays(random.Next((endRange - start).Days)).ToUniversalTime(),
                        Price = random.Next(1, 10000),
                    });
                }
                else
                {
                    ticketDto.Add(new CreateTicketDto
                    {
                        EventId = instructorList[i].Id,
                        ClientId = clientsList[i-1].Id,
                        PurchaseDate = start.AddDays(random.Next((endRange - start).Days)).ToUniversalTime(),
                        Price = random.Next(1,10000),
                    });
                }

            }

            var ticketList = ticketDto.AsQueryable().ProjectToType<Ticket>().ToList();

            await ticketRepository.BulkCreate(ticketList);

            //Add Slopes
            var slopeDto = new List<CreateSlopeDto>();
            for (int i = 0; i < coef * 5; i++)
            {
                slopeDto.Add(new CreateSlopeDto
                {
                    Name = $"Slope{i}",
                    DifficultyLevel = $"DifficultyLevel{i}",
                    Status = $"Status{i}",
                });
            }

            var slopeList = slopeDto.AsQueryable().ProjectToType<Slope>().ToList();

            await slopeRepository.BulkCreate(slopeList);

            //Add Weather
            var weatherDto = new List<CreateWeatherReportDto>();
            for (int i = 0; i < coef * 3; i++)
            {
                weatherDto.Add(new CreateWeatherReportDto
                {
                    Date = start.AddDays(random.Next((endRange - start).Days)).ToUniversalTime(),
                    WeatherCondition = $"WeatherCondition{i}",
                    Temperature = random.Next(1,30),
                });
            }

            var weatherList = weatherDto.AsQueryable().ProjectToType<WeatherReport>().ToList();

            await weatherRepository.BulkCreate(weatherList);

            //Add Services
            var serviceDto = new List<CreateServiceDto>();
            for (int i = 0; i < coef; i++)
            {
                serviceDto.Add(new CreateServiceDto
                {
                    Name = $"ServiceName{i}",
                    Description = $"ServiceDescription{i}",
                    Price = random.Next(1, 10000),
                });
            }

            var serviceList = serviceDto.AsQueryable().ProjectToType<Service>().ToList();

            await serviceRepository.BulkCreate(serviceList);

            //Add ServicesOrder
            var servicesOrderDto = new List<CreateServiceOrderDto>();

            for (int i = 0; i < clientsList.Count(); i++)
            {
                if (i % 2 == 0)
                {
                    servicesOrderDto.Add(new CreateServiceOrderDto
                    {
                        ClientId = clientsList[i].Id,
                        ServiceId = serviceList[i].Id,
                        OrderDate = start.AddDays(random.Next((endRange - start).Days)).ToUniversalTime(),
                    });
                }
                else
                {
                    servicesOrderDto.Add(new CreateServiceOrderDto
                    {
                        ClientId = clientsList[i-1].Id,
                        ServiceId = serviceList[i].Id,
                        OrderDate = start.AddDays(random.Next((endRange - start).Days)).ToUniversalTime(),
                    });
                }

            }
            var serviceOrderList = servicesOrderDto.AsQueryable().ProjectToType<ServiceOrder>().ToList();

            await serviceOrderRepository.BulkCreate(serviceOrderList);

            //Add Rooms
            var roomDto = new List<CreateRoomDto>();
            for (int i = 0; i < coef; i++)
            {
                roomDto.Add(new CreateRoomDto
                {
                    Type = $"RoomType{i}",
                    PricePerNight = random.Next(1, 100000),
                    Capacity = random.Next(1, 6),
                });
            }

            var roomList = roomDto.AsQueryable().ProjectToType<Room>().ToList();

            await roomRepository.BulkCreate(roomList);

            //Add ServicesOrder
            var bookingDto = new List<CreateBookingDto>();

            for (int i = 0; i < clientsList.Count(); i++)
            {
                if (i % 2 == 0)
                {
                    bookingDto.Add(new CreateBookingDto
                    {
                        ClientId = clientsList[i].Id,
                        RoomId = serviceList[i].Id,
                        CheckInDate = start.AddDays(random.Next((endRange - start).Days)).ToUniversalTime(),
                        CheckOutDate = start.AddDays(random.Next((endRange - start).Days)).ToUniversalTime(),
                        Status = $"Status{i}"
                    });
                }
                else
                {
                    bookingDto.Add(new CreateBookingDto
                    {
                        ClientId = clientsList[i-1].Id,
                        RoomId = serviceList[i].Id,
                        CheckInDate = start.AddDays(random.Next((endRange - start).Days)).ToUniversalTime(),
                        CheckOutDate = start.AddDays(random.Next((endRange - start).Days)).ToUniversalTime(),
                        Status = $"Status{i}"
                    });
                }

            }
            var bookingList = bookingDto.AsQueryable().ProjectToType<Booking>().ToList();

            await bookingRepository.BulkCreate(bookingList);

            //Add Equipments
            var equipmentsDto = new List<CreateEquipmentDto>();
            for (int i = 0; i < coef; i++)
            {
                equipmentsDto.Add(new CreateEquipmentDto
                {
                    Name = $"EquipmentName{i}"
                });
            }

            var equipmentsList = equipmentsDto.AsQueryable().ProjectToType<Equipment>().ToList();

            await equipmentRepository.BulkCreate(equipmentsList);

            //Add MaintenanceRequest
            var maintenanceRequestDto = new List<CreateMaintenanceRequestDto>();
            for (int i = 0; i < equipmentsList.Count()/2; i++)
            {
                maintenanceRequestDto.Add(new CreateMaintenanceRequestDto
                {
                    EquipmentId = equipmentsList[i].Id,
                    StartDate = start.AddDays(random.Next((endRange - start).Days)).ToUniversalTime(),
                    EndDate = start.AddDays(random.Next((endRange - start).Days)).ToUniversalTime(),
                    Status = $"Status{i}"
                });
            }

            var maintenanceRequestList = maintenanceRequestDto.AsQueryable().ProjectToType<MaintenanceRequest>().ToList();

            await maintenanceRequestRepository.BulkCreate(maintenanceRequestList);

            //Add EquipmentRental
            var equipmentRentalDto = new List<CreateEquipmentRentalDto>();

            for (int i = 0; i < clientsList.Count(); i++)
            {
                if (i % 2 == 0)
                {
                    equipmentRentalDto.Add(new CreateEquipmentRentalDto
                    {
                        ClientId = clientsList[i].Id,
                        EquipmentId = serviceList[i].Id,
                        StartDate = start.AddDays(random.Next((endRange - start).Days)).ToUniversalTime(),
                        EndDate = start.AddDays(random.Next((endRange - start).Days)).ToUniversalTime(),
                        RentalPrice = random.Next(1,1000)
                    });
                }
                else
                {
                    equipmentRentalDto.Add(new CreateEquipmentRentalDto
                    {
                        ClientId = clientsList[i-1].Id,
                        EquipmentId = serviceList[i].Id,
                        StartDate = start.AddDays(random.Next((endRange - start).Days)).ToUniversalTime(),
                        EndDate = start.AddDays(random.Next((endRange - start).Days)).ToUniversalTime(),
                        RentalPrice = random.Next(1, 1000)
                    });
                }

            }
            var equipmentRentalList = equipmentRentalDto.AsQueryable().ProjectToType<EquipmentRental>().ToList();

            await equipmentRentalRepository.BulkCreate(equipmentRentalList);
        }
    }
}
