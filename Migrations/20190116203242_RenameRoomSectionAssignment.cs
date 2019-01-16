using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class RenameRoomSectionAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomSectionAssignment");

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
                        name: "FK_SectionRoomAssignments_RoomTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "RoomTypes",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectionRoomAssignments");

            migrationBuilder.CreateTable(
                name: "RoomSectionAssignment",
                columns: table => new
                {
                    SectionId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomSectionAssignment", x => new { x.SectionId, x.RoomId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_RoomSectionAssignment_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomSectionAssignment_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomSectionAssignment_RoomTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomSectionAssignment_RoomId",
                table: "RoomSectionAssignment",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomSectionAssignment_TypeId",
                table: "RoomSectionAssignment",
                column: "TypeId");
        }
    }
}
