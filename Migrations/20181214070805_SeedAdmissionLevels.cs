using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class SeedAdmissionLevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO AdmissionLevels (Name) VALUES ('Certificate')");
            migrationBuilder.Sql("INSERT INTO AdmissionLevels (Name) VALUES ('Degree')");
            migrationBuilder.Sql("INSERT INTO AdmissionLevels (Name) VALUES ('Masters')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM AdmissionLevels WHERE Name IN ('Certificate', 'Degree', 'Masters')");
        }
    }
}
