using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class AddMoreColumnsToScheduleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaySchedule_Schedules_ScheduleId",
                table: "DaySchedule");

            migrationBuilder.AlterColumn<int>(
                name: "DayScheduleId",
                table: "DaySession",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleId",
                table: "DaySchedule",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DaySchedule_Schedules_ScheduleId",
                table: "DaySchedule",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaySchedule_Schedules_ScheduleId",
                table: "DaySchedule");

            migrationBuilder.AlterColumn<int>(
                name: "DayScheduleId",
                table: "DaySession",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleId",
                table: "DaySchedule",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_DaySchedule_Schedules_ScheduleId",
                table: "DaySchedule",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
