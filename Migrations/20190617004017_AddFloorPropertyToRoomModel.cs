using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class AddFloorPropertyToRoomModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Colleges_CollegeId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_CollegeId",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CollegeId",
                table: "Rooms",
                column: "CollegeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Colleges_CollegeId",
                table: "Rooms",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
                name: "Floor",
                table: "Rooms");

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
    }
}
