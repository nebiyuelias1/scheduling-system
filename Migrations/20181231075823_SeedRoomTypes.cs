using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class SeedRoomTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO RoomTypes (Name) VALUES ('Lecture')");
            migrationBuilder.Sql("INSERT INTO RoomTypes (Name) VALUES ('Lab')");
            migrationBuilder.Sql("INSERT INTO RoomTypes (Name) VALUES ('Tutor')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM RoomTypes WHERE Name IN ('Lecture', 'Lab', 'Tutor')");
        }
    }
}
