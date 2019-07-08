using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class ModifyCourseOfferingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferingRoomAssignments_Rooms_RoomId",
                table: "CourseOfferingRoomAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseOfferingRoomAssignments",
                table: "CourseOfferingRoomAssignments");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "CourseOfferingRoomAssignments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CourseOfferingRoomAssignments",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseOfferingRoomAssignments",
                table: "CourseOfferingRoomAssignments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferingRoomAssignments_CourseOfferingId",
                table: "CourseOfferingRoomAssignments",
                column: "CourseOfferingId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferingRoomAssignments_Rooms_RoomId",
                table: "CourseOfferingRoomAssignments",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferingRoomAssignments_Rooms_RoomId",
                table: "CourseOfferingRoomAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseOfferingRoomAssignments",
                table: "CourseOfferingRoomAssignments");

            migrationBuilder.DropIndex(
                name: "IX_CourseOfferingRoomAssignments_CourseOfferingId",
                table: "CourseOfferingRoomAssignments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CourseOfferingRoomAssignments");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "CourseOfferingRoomAssignments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseOfferingRoomAssignments",
                table: "CourseOfferingRoomAssignments",
                columns: new[] { "CourseOfferingId", "RoomId", "TypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferingRoomAssignments_Rooms_RoomId",
                table: "CourseOfferingRoomAssignments",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
