using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class ModifyDomainModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomRoomType");

            migrationBuilder.CreateTable(
                name: "RoomTypeAssignment",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypeAssignment", x => new { x.RoomId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_RoomTypeAssignment_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomTypeAssignment_RoomTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypeAssignment_TypeId",
                table: "RoomTypeAssignment",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomTypeAssignment");

            migrationBuilder.CreateTable(
                name: "RoomRoomType",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false),
                    RoomTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomRoomType", x => new { x.RoomId, x.RoomTypeId });
                    table.ForeignKey(
                        name: "FK_RoomRoomType_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomRoomType_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomRoomType_RoomTypeId",
                table: "RoomRoomType",
                column: "RoomTypeId");
        }
    }
}
