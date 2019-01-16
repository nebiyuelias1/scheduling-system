using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class AddCourseOfferingInstructorAssignments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferings_Instructors_InstructorId",
                table: "CourseOfferings");

            migrationBuilder.DropIndex(
                name: "IX_CourseOfferings_InstructorId",
                table: "CourseOfferings");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "CourseOfferings");

            migrationBuilder.CreateTable(
                name: "CourseOfferingInstructorAssignment",
                columns: table => new
                {
                    CourseOfferingId = table.Column<int>(nullable: false),
                    InstructorId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOfferingInstructorAssignment", x => new { x.CourseOfferingId, x.InstructorId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_CourseOfferingInstructorAssignment_CourseOfferings_CourseOfferingId",
                        column: x => x.CourseOfferingId,
                        principalTable: "CourseOfferings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseOfferingInstructorAssignment_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseOfferingInstructorAssignment_RoomTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferingInstructorAssignment_InstructorId",
                table: "CourseOfferingInstructorAssignment",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferingInstructorAssignment_TypeId",
                table: "CourseOfferingInstructorAssignment",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseOfferingInstructorAssignment");

            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "CourseOfferings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferings_InstructorId",
                table: "CourseOfferings",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferings_Instructors_InstructorId",
                table: "CourseOfferings",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
