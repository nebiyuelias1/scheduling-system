using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class SeedWeekDaysTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO WeekDays (Name, Number) VALUES ('Monday', 0)");
            migrationBuilder.Sql("INSERT INTO WeekDays (Name, Number) VALUES ('Tuesday', 1)");
            migrationBuilder.Sql("INSERT INTO WeekDays (Name, Number) VALUES ('Wednesday', 2)");
            migrationBuilder.Sql("INSERT INTO WeekDays (Name, Number) VALUES ('Thursday', 3)");
            migrationBuilder.Sql("INSERT INTO WeekDays (Name, Number) VALUES ('Friday', 4)");
            migrationBuilder.Sql("INSERT INTO WeekDays (Name, Number) VALUES ('Saturday', 5)");
            migrationBuilder.Sql("INSERT INTO WeekDays (Name, Number) VALUES ('Sunday', 6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM WeekDays WHERE Number IN (0, 1, 2, 3, 4, 5, 6, 7)");
        }
    }
}
