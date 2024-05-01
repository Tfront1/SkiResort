using Microsoft.EntityFrameworkCore.Migrations;
using SkiResort.Infrastructure.Database.Views;

#nullable disable

namespace SkiResort.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Views : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(ClientEventsCountViewCode.Code);

            migrationBuilder.Sql(InstructorLessonsCountViewCode.Code);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
