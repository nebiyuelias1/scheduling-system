using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class CascadeDeleteCourseOfferingAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorAssignments_CourseOfferings_CourseOfferingId",
                table: "InstructorAssignments");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorAssignments_CourseOfferings_CourseOfferingId",
                table: "InstructorAssignments",
                column: "CourseOfferingId",
                principalTable: "CourseOfferings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorAssignments_CourseOfferings_CourseOfferingId",
                table: "InstructorAssignments");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorAssignments_CourseOfferings_CourseOfferingId",
                table: "InstructorAssignments",
                column: "CourseOfferingId",
                principalTable: "CourseOfferings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
