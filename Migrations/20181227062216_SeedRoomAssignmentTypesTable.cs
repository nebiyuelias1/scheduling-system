using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class SeedRoomAssignmentTypesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO RoomAssignmentTypes (Name) VALUES ('Lecture')");
            migrationBuilder.Sql("INSERT INTO RoomAssignmentTypes (Name) VALUES ('Lab')");
            migrationBuilder.Sql("INSERT INTO RoomAssignmentTypes (Name) VALUES ('Tutor')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM RoomAssignmentTypes WHERE Name IN ('Lecture', 'Lab', 'Tutor')");
        }
    }
}
