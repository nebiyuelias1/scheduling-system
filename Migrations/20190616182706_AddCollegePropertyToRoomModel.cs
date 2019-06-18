using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class AddCollegePropertyToRoomModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollegeId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CollegeId",
                table: "Rooms",
                column: "CollegeId",
                unique: true,
                filter: "[CollegeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Colleges_CollegeId",
                table: "Rooms",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Colleges_CollegeId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_CollegeId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CollegeId",
                table: "Rooms");
        }
    }
}
