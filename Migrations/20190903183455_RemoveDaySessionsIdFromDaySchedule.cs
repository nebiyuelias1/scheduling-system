using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class RemoveDaySessionsIdFromDaySchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntries_DaySession_DaySessionId",
                table: "ScheduleEntries");

            migrationBuilder.DropColumn(
                name: "DaySessionId",
                table: "DaySchedule");

            migrationBuilder.AlterColumn<int>(
                name: "DaySessionId",
                table: "ScheduleEntries",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntries_DaySession_DaySessionId",
                table: "ScheduleEntries",
                column: "DaySessionId",
                principalTable: "DaySession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntries_DaySession_DaySessionId",
                table: "ScheduleEntries");

            migrationBuilder.AlterColumn<int>(
                name: "DaySessionId",
                table: "ScheduleEntries",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "DaySessionId",
                table: "DaySchedule",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntries_DaySession_DaySessionId",
                table: "ScheduleEntries",
                column: "DaySessionId",
                principalTable: "DaySession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
