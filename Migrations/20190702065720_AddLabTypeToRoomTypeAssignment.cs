using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class AddLabTypeToRoomTypeAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LabTypeId",
                table: "RoomTypeAssignments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypeAssignments_LabTypeId",
                table: "RoomTypeAssignments",
                column: "LabTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomTypeAssignments_LabTypes_LabTypeId",
                table: "RoomTypeAssignments",
                column: "LabTypeId",
                principalTable: "LabTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomTypeAssignments_LabTypes_LabTypeId",
                table: "RoomTypeAssignments");

            migrationBuilder.DropIndex(
                name: "IX_RoomTypeAssignments_LabTypeId",
                table: "RoomTypeAssignments");

            migrationBuilder.DropColumn(
                name: "LabTypeId",
                table: "RoomTypeAssignments");
        }
    }
}
