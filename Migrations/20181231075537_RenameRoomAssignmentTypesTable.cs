using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulingSystem.Migrations
{
    public partial class RenameRoomAssignmentTypesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomSectionAssignment_RoomAssignmentTypes_TypeId",
                table: "RoomSectionAssignment");

            migrationBuilder.DropTable(
                name: "RoomAssignmentTypes");

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomSectionAssignment_RoomTypes_TypeId",
                table: "RoomSectionAssignment",
                column: "TypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomSectionAssignment_RoomTypes_TypeId",
                table: "RoomSectionAssignment");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.CreateTable(
                name: "RoomAssignmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAssignmentTypes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomSectionAssignment_RoomAssignmentTypes_TypeId",
                table: "RoomSectionAssignment",
                column: "TypeId",
                principalTable: "RoomAssignmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
