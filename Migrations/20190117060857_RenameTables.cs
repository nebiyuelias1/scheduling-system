using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class RenameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseOfferingInstructorAssignments");

            migrationBuilder.CreateTable(
                name: "InstructorAssignments",
                columns: table => new
                {
                    CourseOfferingId = table.Column<int>(nullable: false),
                    InstructorId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorAssignments", x => new { x.CourseOfferingId, x.InstructorId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_InstructorAssignments_CourseOfferings_CourseOfferingId",
                        column: x => x.CourseOfferingId,
                        principalTable: "CourseOfferings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorAssignments_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorAssignments_RoomTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstructorAssignments_InstructorId",
                table: "InstructorAssignments",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorAssignments_TypeId",
                table: "InstructorAssignments",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructorAssignments");

            migrationBuilder.CreateTable(
                name: "CourseOfferingInstructorAssignments",
                columns: table => new
                {
                    CourseOfferingId = table.Column<int>(nullable: false),
                    InstructorId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOfferingInstructorAssignments", x => new { x.CourseOfferingId, x.InstructorId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_CourseOfferingInstructorAssignments_CourseOfferings_CourseOfferingId",
                        column: x => x.CourseOfferingId,
                        principalTable: "CourseOfferings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseOfferingInstructorAssignments_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseOfferingInstructorAssignments_RoomTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferingInstructorAssignments_InstructorId",
                table: "CourseOfferingInstructorAssignments",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferingInstructorAssignments_TypeId",
                table: "CourseOfferingInstructorAssignments",
                column: "TypeId");
        }
    }
}
