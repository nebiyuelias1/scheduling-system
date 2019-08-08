using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class AddDaySessionToScheduleEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaySession_ScheduleEntries_ScheduleEntryId",
                table: "DaySession");

            migrationBuilder.DropIndex(
                name: "IX_DaySession_ScheduleEntryId",
                table: "DaySession");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "DaySession");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "DaySession");

            migrationBuilder.DropColumn(
                name: "ScheduleEntryId",
                table: "DaySession");

            migrationBuilder.AddColumn<int>(
                name: "DaySessionId",
                table: "ScheduleEntries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "ScheduleEntries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "ScheduleEntries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleEntries_DaySessionId",
                table: "ScheduleEntries",
                column: "DaySessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntries_DaySession_DaySessionId",
                table: "ScheduleEntries",
                column: "DaySessionId",
                principalTable: "DaySession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntries_DaySession_DaySessionId",
                table: "ScheduleEntries");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleEntries_DaySessionId",
                table: "ScheduleEntries");

            migrationBuilder.DropColumn(
                name: "DaySessionId",
                table: "ScheduleEntries");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "ScheduleEntries");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "ScheduleEntries");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "DaySession",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "DaySession",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleEntryId",
                table: "DaySession",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DaySession_ScheduleEntryId",
                table: "DaySession",
                column: "ScheduleEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DaySession_ScheduleEntries_ScheduleEntryId",
                table: "DaySession",
                column: "ScheduleEntryId",
                principalTable: "ScheduleEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
