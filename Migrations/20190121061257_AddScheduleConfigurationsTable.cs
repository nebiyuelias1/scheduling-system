using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class AddScheduleConfigurationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduleConfigurations",
                columns: table => new
                {
                    AdmissionLevelId = table.Column<int>(nullable: false),
                    ProgramTypeId = table.Column<int>(nullable: false),
                    NumberOfDaysPerWeek = table.Column<int>(nullable: false),
                    NumberOfPeriodsPerDay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleConfigurations", x => new { x.AdmissionLevelId, x.ProgramTypeId });
                    table.ForeignKey(
                        name: "FK_ScheduleConfigurations_AdmissionLevels_AdmissionLevelId",
                        column: x => x.AdmissionLevelId,
                        principalTable: "AdmissionLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleConfigurations_ProgramTypes_ProgramTypeId",
                        column: x => x.ProgramTypeId,
                        principalTable: "ProgramTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleConfigurations_ProgramTypeId",
                table: "ScheduleConfigurations",
                column: "ProgramTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleConfigurations");
        }
    }
}
