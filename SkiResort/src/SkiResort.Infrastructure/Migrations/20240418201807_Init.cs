using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiResort.Infrastructure.Migrations;

/// <inheritdoc />
public partial class Init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Clients",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                Phone = table.Column<string>(type: "text", nullable: true),
                Email = table.Column<string>(type: "text", nullable: true),
                DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Clients", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Employees",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                Position = table.Column<string>(type: "text", nullable: false),
                Department = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Employees", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Equipments",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Equipments", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Events",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false),
                StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                Location = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Events", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Instructors",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                Specialization = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Instructors", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Lifts",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false),
                Status = table.Column<string>(type: "text", nullable: false),
                Type = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Lifts", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Roles",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                RoleName = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Roles", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Rooms",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Type = table.Column<string>(type: "text", nullable: false),
                PricePerNight = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                Capacity = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Rooms", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Services",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false),
                Description = table.Column<string>(type: "text", nullable: true),
                Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Services", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Slopes",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false),
                DifficultyLevel = table.Column<string>(type: "text", nullable: false),
                Status = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Slopes", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Transportations",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Type = table.Column<string>(type: "text", nullable: false),
                Schedule = table.Column<string>(type: "text", nullable: false),
                Capacity = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Transportations", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "WeatherReports",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                WeatherCondition = table.Column<string>(type: "text", nullable: false),
                Temperature = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_WeatherReports", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Payrolls",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                PayDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Payrolls", x => x.Id);
                table.ForeignKey(
                    name: "FK_Payrolls_Employees_EmployeeId",
                    column: x => x.EmployeeId,
                    principalTable: "Employees",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "EquipmentRentals",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                EquipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                RentalPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EquipmentRentals", x => x.Id);
                table.ForeignKey(
                    name: "FK_EquipmentRentals_Clients_ClientId",
                    column: x => x.ClientId,
                    principalTable: "Clients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_EquipmentRentals_Equipments_EquipmentId",
                    column: x => x.EquipmentId,
                    principalTable: "Equipments",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "MaintenanceRequests",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                EquipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MaintenanceRequests", x => x.Id);
                table.ForeignKey(
                    name: "FK_MaintenanceRequests_Equipments_EquipmentId",
                    column: x => x.EquipmentId,
                    principalTable: "Equipments",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Tickets",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                EventId = table.Column<Guid>(type: "uuid", nullable: false),
                ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                PurchaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tickets", x => x.Id);
                table.ForeignKey(
                    name: "FK_Tickets_Clients_ClientId",
                    column: x => x.ClientId,
                    principalTable: "Clients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Tickets_Events_EventId",
                    column: x => x.EventId,
                    principalTable: "Events",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "SkiLessons",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                InstructorId = table.Column<Guid>(type: "uuid", nullable: false),
                ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                Duration = table.Column<TimeSpan>(type: "interval", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SkiLessons", x => x.Id);
                table.ForeignKey(
                    name: "FK_SkiLessons_Clients_ClientId",
                    column: x => x.ClientId,
                    principalTable: "Clients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_SkiLessons_Instructors_InstructorId",
                    column: x => x.InstructorId,
                    principalTable: "Instructors",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                Username = table.Column<string>(type: "text", nullable: false),
                Password = table.Column<string>(type: "text", nullable: false),
                Email = table.Column<string>(type: "text", nullable: false),
                LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
                table.ForeignKey(
                    name: "FK_Users_Roles_RoleId",
                    column: x => x.RoleId,
                    principalTable: "Roles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Bookings",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                CheckInDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CheckOutDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Bookings", x => x.Id);
                table.ForeignKey(
                    name: "FK_Bookings_Clients_ClientId",
                    column: x => x.ClientId,
                    principalTable: "Clients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Bookings_Rooms_RoomId",
                    column: x => x.RoomId,
                    principalTable: "Rooms",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "ServiceOrders",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                ServiceId = table.Column<Guid>(type: "uuid", nullable: false),
                OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ServiceOrders", x => x.Id);
                table.ForeignKey(
                    name: "FK_ServiceOrders_Clients_ClientId",
                    column: x => x.ClientId,
                    principalTable: "Clients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_ServiceOrders_Services_ServiceId",
                    column: x => x.ServiceId,
                    principalTable: "Services",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Bookings_ClientId",
            table: "Bookings",
            column: "ClientId");

        migrationBuilder.CreateIndex(
            name: "IX_Bookings_RoomId",
            table: "Bookings",
            column: "RoomId");

        migrationBuilder.CreateIndex(
            name: "IX_EquipmentRentals_ClientId",
            table: "EquipmentRentals",
            column: "ClientId");

        migrationBuilder.CreateIndex(
            name: "IX_EquipmentRentals_EquipmentId",
            table: "EquipmentRentals",
            column: "EquipmentId");

        migrationBuilder.CreateIndex(
            name: "IX_MaintenanceRequests_EquipmentId",
            table: "MaintenanceRequests",
            column: "EquipmentId");

        migrationBuilder.CreateIndex(
            name: "IX_Payrolls_EmployeeId",
            table: "Payrolls",
            column: "EmployeeId");

        migrationBuilder.CreateIndex(
            name: "IX_ServiceOrders_ClientId",
            table: "ServiceOrders",
            column: "ClientId");

        migrationBuilder.CreateIndex(
            name: "IX_ServiceOrders_ServiceId",
            table: "ServiceOrders",
            column: "ServiceId");

        migrationBuilder.CreateIndex(
            name: "IX_SkiLessons_ClientId",
            table: "SkiLessons",
            column: "ClientId");

        migrationBuilder.CreateIndex(
            name: "IX_SkiLessons_InstructorId",
            table: "SkiLessons",
            column: "InstructorId");

        migrationBuilder.CreateIndex(
            name: "IX_Tickets_ClientId",
            table: "Tickets",
            column: "ClientId");

        migrationBuilder.CreateIndex(
            name: "IX_Tickets_EventId",
            table: "Tickets",
            column: "EventId");

        migrationBuilder.CreateIndex(
            name: "IX_Users_RoleId",
            table: "Users",
            column: "RoleId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Bookings");

        migrationBuilder.DropTable(
            name: "EquipmentRentals");

        migrationBuilder.DropTable(
            name: "Lifts");

        migrationBuilder.DropTable(
            name: "MaintenanceRequests");

        migrationBuilder.DropTable(
            name: "Payrolls");

        migrationBuilder.DropTable(
            name: "ServiceOrders");

        migrationBuilder.DropTable(
            name: "SkiLessons");

        migrationBuilder.DropTable(
            name: "Slopes");

        migrationBuilder.DropTable(
            name: "Tickets");

        migrationBuilder.DropTable(
            name: "Transportations");

        migrationBuilder.DropTable(
            name: "Users");

        migrationBuilder.DropTable(
            name: "WeatherReports");

        migrationBuilder.DropTable(
            name: "Rooms");

        migrationBuilder.DropTable(
            name: "Equipments");

        migrationBuilder.DropTable(
            name: "Employees");

        migrationBuilder.DropTable(
            name: "Services");

        migrationBuilder.DropTable(
            name: "Instructors");

        migrationBuilder.DropTable(
            name: "Clients");

        migrationBuilder.DropTable(
            name: "Events");

        migrationBuilder.DropTable(
            name: "Roles");
    }
}
