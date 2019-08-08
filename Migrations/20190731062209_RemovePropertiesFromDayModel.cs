using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class RemovePropertiesFromDayModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Schedules_ScheduleId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_WeekDays_WeekDayId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntries_Days_DayId",
                table: "ScheduleEntries");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleEntries_DayId",
                table: "ScheduleEntries");

            migrationBuilder.DropIndex(
                name: "IX_Days_ScheduleId",
                table: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Days_WeekDayId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "ScheduleEntries");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "WeekDayId",
                table: "Days");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "ScheduleEntries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Days",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeekDayId",
                table: "Days",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleEntries_DayId",
                table: "ScheduleEntries",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_ScheduleId",
                table: "Days",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_WeekDayId",
                table: "Days",
                column: "WeekDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Schedules_ScheduleId",
                table: "Days",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_WeekDays_WeekDayId",
                table: "Days",
                column: "WeekDayId",
                principalTable: "WeekDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntries_Days_DayId",
                table: "ScheduleEntries",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
