using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class SeedProgramTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ProgramTypes (Name) VALUES ('Regular')");
            migrationBuilder.Sql("INSERT INTO ProgramTypes (Name) VALUES ('Extension')");
            migrationBuilder.Sql("INSERT INTO ProgramTypes (Name) VALUES ('Summer')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM ProgramTypes WHERE Name IN ('Regular', 'Extension', 'Summer')");
        }
    }
}
