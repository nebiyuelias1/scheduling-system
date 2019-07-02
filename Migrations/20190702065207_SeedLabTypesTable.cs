using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class SeedLabTypesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO LabTypes VALUES ('Computer')");
            migrationBuilder.Sql("INSERT INTO LabTypes VALUES ('Electronics')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM LabTypes WHERE Name IN 'Computer'");
            migrationBuilder.Sql("DELETE FROM LabTypes WHERE Name IN 'Electronics'");
        }
    }
}
