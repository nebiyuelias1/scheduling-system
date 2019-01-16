using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class RenameRoomTypeAssignmentToRoomTypeAssignments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomTypeAssignment_Rooms_RoomId",
                table: "RoomTypeAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomTypeAssignment_RoomTypes_TypeId",
                table: "RoomTypeAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomTypeAssignment",
                table: "RoomTypeAssignment");

            migrationBuilder.RenameTable(
                name: "RoomTypeAssignment",
                newName: "RoomTypeAssignments");

            migrationBuilder.RenameIndex(
                name: "IX_RoomTypeAssignment_TypeId",
                table: "RoomTypeAssignments",
                newName: "IX_RoomTypeAssignments_TypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomTypeAssignments",
                table: "RoomTypeAssignments",
                columns: new[] { "RoomId", "TypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomTypeAssignments_Rooms_RoomId",
                table: "RoomTypeAssignments",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomTypeAssignments_RoomTypes_TypeId",
                table: "RoomTypeAssignments",
                column: "TypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomTypeAssignments_Rooms_RoomId",
                table: "RoomTypeAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomTypeAssignments_RoomTypes_TypeId",
                table: "RoomTypeAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomTypeAssignments",
                table: "RoomTypeAssignments");

            migrationBuilder.RenameTable(
                name: "RoomTypeAssignments",
                newName: "RoomTypeAssignment");

            migrationBuilder.RenameIndex(
                name: "IX_RoomTypeAssignments_TypeId",
                table: "RoomTypeAssignment",
                newName: "IX_RoomTypeAssignment_TypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomTypeAssignment",
                table: "RoomTypeAssignment",
                columns: new[] { "RoomId", "TypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomTypeAssignment_Rooms_RoomId",
                table: "RoomTypeAssignment",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomTypeAssignment_RoomTypes_TypeId",
                table: "RoomTypeAssignment",
                column: "TypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
