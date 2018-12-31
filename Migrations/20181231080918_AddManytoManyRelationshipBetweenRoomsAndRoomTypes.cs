using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class AddManytoManyRelationshipBetweenRoomsAndRoomTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLabRoom",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "IsLectureRoom",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "IsSharedRoom",
                table: "Rooms");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomRoomType");

            migrationBuilder.AddColumn<bool>(
                name: "IsLabRoom",
                table: "Rooms",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLectureRoom",
                table: "Rooms",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSharedRoom",
                table: "Rooms",
                nullable: false,
                defaultValue: false);
        }
    }
}
