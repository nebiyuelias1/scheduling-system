using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class AddSchedules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Days",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId1",
                table: "Days",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcademicSemesterId = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_AcademicSemesters_AcademicSemesterId",
                        column: x => x.AcademicSemesterId,
                        principalTable: "AcademicSemesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Days_ScheduleId",
                table: "Days",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_ScheduleId1",
                table: "Days",
                column: "ScheduleId1");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_AcademicSemesterId",
                table: "Schedules",
                column: "AcademicSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_SectionId",
                table: "Schedules",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Schedules_ScheduleId",
                table: "Days",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Schedules_ScheduleId1",
                table: "Days",
                column: "ScheduleId1",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Schedules_ScheduleId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_Schedules_ScheduleId1",
                table: "Days");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Days_ScheduleId",
                table: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Days_ScheduleId1",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "ScheduleId1",
                table: "Days");
        }
    }
}
