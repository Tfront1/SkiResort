using Microsoft.EntityFrameworkCore.Migrations;
using SkiResort.Infrastructure.Database.Views;

#nullable disable

namespace SkiResort.Infrastructure.Migrations;

/// <inheritdoc />
public partial class ViewsTriggers : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(ClientEventsCountViewCode.Code);

        migrationBuilder.Sql(InstructorLessonsCountViewCode.Code);

        migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION log_slopes_activity() RETURNS TRIGGER AS $$
                BEGIN
                    INSERT INTO database_logs (event_date, table_name)
                    VALUES (NOW(), 'slopes');
                    RETURN NEW;
                END;
                $$ LANGUAGE plpgsql;

                CREATE TRIGGER after_slope_insert
                AFTER INSERT ON slopes
                FOR EACH ROW
                EXECUTE PROCEDURE log_slopes_activity();

                CREATE TRIGGER after_slope_update
                AFTER UPDATE ON slopes
                FOR EACH ROW
                EXECUTE PROCEDURE log_slopes_activity();

                CREATE TRIGGER after_slope_delete
                AFTER DELETE ON slopes
                FOR EACH ROW
                EXECUTE PROCEDURE log_slopes_activity();
            ");

        migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION log_clients_activity() RETURNS TRIGGER AS $$
                BEGIN
                    INSERT INTO database_logs (event_date, table_name)
                    VALUES (NOW(), 'clients');
                    RETURN NEW;
                END;
                $$ LANGUAGE plpgsql;

                CREATE TRIGGER after_clients_insert
                AFTER INSERT ON clients
                FOR EACH ROW
                EXECUTE PROCEDURE log_clients_activity();

                CREATE TRIGGER after_clients_update
                AFTER UPDATE ON clients
                FOR EACH ROW
                EXECUTE PROCEDURE log_clients_activity();

                CREATE TRIGGER after_clients_delete
                AFTER DELETE ON clients
                FOR EACH ROW
                EXECUTE PROCEDURE log_clients_activity();
            ");

        migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION log_weather_reports_activity() RETURNS TRIGGER AS $$
                BEGIN
                    INSERT INTO database_logs (event_date, table_name)
                    VALUES (NOW(), 'weather_reports');
                    RETURN NEW;
                END;
                $$ LANGUAGE plpgsql;

                CREATE TRIGGER after_weather_reports_insert
                AFTER INSERT ON weather_reports
                FOR EACH ROW
                EXECUTE PROCEDURE log_weather_reports_activity();

                CREATE TRIGGER after_weather_reports_update
                AFTER UPDATE ON weather_reports
                FOR EACH ROW
                EXECUTE PROCEDURE log_weather_reports_activity();

                CREATE TRIGGER after_weather_reports_delete
                AFTER DELETE ON weather_reports
                FOR EACH ROW
                EXECUTE PROCEDURE log_weather_reports_activity();
            ");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {

    }
}
