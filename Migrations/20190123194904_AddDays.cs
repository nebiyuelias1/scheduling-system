using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class AddDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "ScheduleEntries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WeekDayId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Days_WeekDays_WeekDayId",
                        column: x => x.WeekDayId,
                        principalTable: "WeekDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleEntries_DayId",
                table: "ScheduleEntries",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_WeekDayId",
                table: "Days",
                column: "WeekDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntries_Days_DayId",
                table: "ScheduleEntries",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntries_Days_DayId",
                table: "ScheduleEntries");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleEntries_DayId",
                table: "ScheduleEntries");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "ScheduleEntries");
        }
    }
}
