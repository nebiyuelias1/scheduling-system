using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class RenameRoomTypesToTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorAssignments_RoomTypes_TypeId",
                table: "InstructorAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomTypeAssignments_RoomTypes_TypeId",
                table: "RoomTypeAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntries_RoomTypes_TypeId",
                table: "ScheduleEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionRoomAssignments_RoomTypes_TypeId",
                table: "SectionRoomAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomTypes",
                table: "RoomTypes");

            migrationBuilder.RenameTable(
                name: "RoomTypes",
                newName: "Types");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Types",
                table: "Types",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorAssignments_Types_TypeId",
                table: "InstructorAssignments",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomTypeAssignments_Types_TypeId",
                table: "RoomTypeAssignments",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntries_Types_TypeId",
                table: "ScheduleEntries",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionRoomAssignments_Types_TypeId",
                table: "SectionRoomAssignments",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorAssignments_Types_TypeId",
                table: "InstructorAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomTypeAssignments_Types_TypeId",
                table: "RoomTypeAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntries_Types_TypeId",
                table: "ScheduleEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionRoomAssignments_Types_TypeId",
                table: "SectionRoomAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Types",
                table: "Types");

            migrationBuilder.RenameTable(
                name: "Types",
                newName: "RoomTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomTypes",
                table: "RoomTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorAssignments_RoomTypes_TypeId",
                table: "InstructorAssignments",
                column: "TypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomTypeAssignments_RoomTypes_TypeId",
                table: "RoomTypeAssignments",
                column: "TypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntries_RoomTypes_TypeId",
                table: "ScheduleEntries",
                column: "TypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionRoomAssignments_RoomTypes_TypeId",
                table: "SectionRoomAssignments",
                column: "TypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
