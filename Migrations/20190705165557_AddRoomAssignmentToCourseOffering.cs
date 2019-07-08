using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class AddRoomAssignmentToCourseOffering : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectionRoomAssignments");

            migrationBuilder.CreateTable(
                name: "CourseOfferingRoomAssignments",
                columns: table => new
                {
                    CourseOfferingId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOfferingRoomAssignments", x => new { x.CourseOfferingId, x.RoomId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_CourseOfferingRoomAssignments_CourseOfferings_CourseOfferingId",
                        column: x => x.CourseOfferingId,
                        principalTable: "CourseOfferings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseOfferingRoomAssignments_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseOfferingRoomAssignments_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferingRoomAssignments_RoomId",
                table: "CourseOfferingRoomAssignments",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferingRoomAssignments_TypeId",
                table: "CourseOfferingRoomAssignments",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseOfferingRoomAssignments");

            migrationBuilder.CreateTable(
                name: "SectionRoomAssignments",
                columns: table => new
                {
                    SectionId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionRoomAssignments", x => new { x.SectionId, x.RoomId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_SectionRoomAssignments_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionRoomAssignments_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionRoomAssignments_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectionRoomAssignments_RoomId",
                table: "SectionRoomAssignments",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionRoomAssignments_TypeId",
                table: "SectionRoomAssignments",
                column: "TypeId");
        }
    }
}
