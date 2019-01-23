using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class ModifyDaysTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Schedules_ScheduleId1",
                table: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Days_ScheduleId1",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "ScheduleId1",
                table: "Days");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScheduleId1",
                table: "Days",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Days_ScheduleId1",
                table: "Days",
                column: "ScheduleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Schedules_ScheduleId1",
                table: "Days",
                column: "ScheduleId1",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
