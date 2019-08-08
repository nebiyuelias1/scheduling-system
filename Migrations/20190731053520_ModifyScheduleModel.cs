using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class ModifyScheduleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Schedules_ScheduleId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntries_Days_DayId",
                table: "ScheduleEntries");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "ScheduleEntries");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "ScheduleEntries");

            migrationBuilder.AlterColumn<int>(
                name: "DayId",
                table: "ScheduleEntries",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "DaySchedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WeekDayId = table.Column<int>(nullable: false),
                    DaySessionId = table.Column<int>(nullable: false),
                    ScheduleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaySchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaySchedule_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DaySchedule_WeekDays_WeekDayId",
                        column: x => x.WeekDayId,
                        principalTable: "WeekDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DaySession",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ScheduleEntryId = table.Column<int>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    DayScheduleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaySession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaySession_DaySchedule_DayScheduleId",
                        column: x => x.DayScheduleId,
                        principalTable: "DaySchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DaySession_ScheduleEntries_ScheduleEntryId",
                        column: x => x.ScheduleEntryId,
                        principalTable: "ScheduleEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaySchedule_ScheduleId",
                table: "DaySchedule",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_DaySchedule_WeekDayId",
                table: "DaySchedule",
                column: "WeekDayId");

            migrationBuilder.CreateIndex(
                name: "IX_DaySession_DayScheduleId",
                table: "DaySession",
                column: "DayScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_DaySession_ScheduleEntryId",
                table: "DaySession",
                column: "ScheduleEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Schedules_ScheduleId",
                table: "Days",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntries_Days_DayId",
                table: "ScheduleEntries",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Schedules_ScheduleId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntries_Days_DayId",
                table: "ScheduleEntries");

            migrationBuilder.DropTable(
                name: "DaySession");

            migrationBuilder.DropTable(
                name: "DaySchedule");

            migrationBuilder.AlterColumn<int>(
                name: "DayId",
                table: "ScheduleEntries",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Schedules_ScheduleId",
                table: "Days",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntries_Days_DayId",
                table: "ScheduleEntries",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
