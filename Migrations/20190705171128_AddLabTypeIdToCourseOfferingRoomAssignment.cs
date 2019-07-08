using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class AddLabTypeIdToCourseOfferingRoomAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LabTypeId",
                table: "CourseOfferingRoomAssignments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferingRoomAssignments_LabTypeId",
                table: "CourseOfferingRoomAssignments",
                column: "LabTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferingRoomAssignments_LabTypes_LabTypeId",
                table: "CourseOfferingRoomAssignments",
                column: "LabTypeId",
                principalTable: "LabTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferingRoomAssignments_LabTypes_LabTypeId",
                table: "CourseOfferingRoomAssignments");

            migrationBuilder.DropIndex(
                name: "IX_CourseOfferingRoomAssignments_LabTypeId",
                table: "CourseOfferingRoomAssignments");

            migrationBuilder.DropColumn(
                name: "LabTypeId",
                table: "CourseOfferingRoomAssignments");
        }
    }
}
