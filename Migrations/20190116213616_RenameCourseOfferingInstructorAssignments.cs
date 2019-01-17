using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class RenameCourseOfferingInstructorAssignments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferingInstructorAssignment_CourseOfferings_CourseOfferingId",
                table: "CourseOfferingInstructorAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferingInstructorAssignment_Instructors_InstructorId",
                table: "CourseOfferingInstructorAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferingInstructorAssignment_RoomTypes_TypeId",
                table: "CourseOfferingInstructorAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseOfferingInstructorAssignment",
                table: "CourseOfferingInstructorAssignment");

            migrationBuilder.RenameTable(
                name: "CourseOfferingInstructorAssignment",
                newName: "CourseOfferingInstructorAssignments");

            migrationBuilder.RenameIndex(
                name: "IX_CourseOfferingInstructorAssignment_TypeId",
                table: "CourseOfferingInstructorAssignments",
                newName: "IX_CourseOfferingInstructorAssignments_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseOfferingInstructorAssignment_InstructorId",
                table: "CourseOfferingInstructorAssignments",
                newName: "IX_CourseOfferingInstructorAssignments_InstructorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseOfferingInstructorAssignments",
                table: "CourseOfferingInstructorAssignments",
                columns: new[] { "CourseOfferingId", "InstructorId", "TypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferingInstructorAssignments_CourseOfferings_CourseOfferingId",
                table: "CourseOfferingInstructorAssignments",
                column: "CourseOfferingId",
                principalTable: "CourseOfferings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferingInstructorAssignments_Instructors_InstructorId",
                table: "CourseOfferingInstructorAssignments",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferingInstructorAssignments_RoomTypes_TypeId",
                table: "CourseOfferingInstructorAssignments",
                column: "TypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferingInstructorAssignments_CourseOfferings_CourseOfferingId",
                table: "CourseOfferingInstructorAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferingInstructorAssignments_Instructors_InstructorId",
                table: "CourseOfferingInstructorAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferingInstructorAssignments_RoomTypes_TypeId",
                table: "CourseOfferingInstructorAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseOfferingInstructorAssignments",
                table: "CourseOfferingInstructorAssignments");

            migrationBuilder.RenameTable(
                name: "CourseOfferingInstructorAssignments",
                newName: "CourseOfferingInstructorAssignment");

            migrationBuilder.RenameIndex(
                name: "IX_CourseOfferingInstructorAssignments_TypeId",
                table: "CourseOfferingInstructorAssignment",
                newName: "IX_CourseOfferingInstructorAssignment_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseOfferingInstructorAssignments_InstructorId",
                table: "CourseOfferingInstructorAssignment",
                newName: "IX_CourseOfferingInstructorAssignment_InstructorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseOfferingInstructorAssignment",
                table: "CourseOfferingInstructorAssignment",
                columns: new[] { "CourseOfferingId", "InstructorId", "TypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferingInstructorAssignment_CourseOfferings_CourseOfferingId",
                table: "CourseOfferingInstructorAssignment",
                column: "CourseOfferingId",
                principalTable: "CourseOfferings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferingInstructorAssignment_Instructors_InstructorId",
                table: "CourseOfferingInstructorAssignment",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferingInstructorAssignment_RoomTypes_TypeId",
                table: "CourseOfferingInstructorAssignment",
                column: "TypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
